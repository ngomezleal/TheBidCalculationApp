using AutoMapper;
using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Models;
using BidCalculation.Domain.Services;
using BidCalculation.Tests.GenericMethods;
using BidCalculationApi.Persistence;
using BidCalculationApi.Services.AssociationFees;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BidCalculation.Tests
{
    public class AssociationFeeTest
    {
        private IEnumerable<AssociationFee> listAssociationFeeDataTest()
        {
            //Emulate data of test (GenFu)
            Random rnd = new Random();
            GenFu.GenFu.Configure<AssociationFee>()
                .Fill(x => x.Id, () => { return rnd.Next(); })
                .Fill(x => x.Description).AsArticleTitle();

            //Execution of data and return of elements
            var listAssociationFee = GenFu.GenFu.ListOf<AssociationFee>(30); //Generate 30 rows like test
            listAssociationFee[0].Id = 1; //Test data in the first index
            listAssociationFee[0].Description = "$5 for an amount between $1 and $500";
            listAssociationFee[0].RangeFrom = 1;
            listAssociationFee[0].RangeUntil = 500;
            listAssociationFee[0].TotalAmount = 500;
            return listAssociationFee;
        }
        private Mock<BidCalculationDbContext> ConfigurationBidCalculationDbContext()
        {
            var dataPruebaListadaLibros = listAssociationFeeDataTest().AsQueryable();

            //Debemos configurar el contexto de Entity Framework. De esta manera
            //emularemos el comportaiento de una entidad. Por defecto EF, configura propiedades por defecto
            var dbSet = new Mock<DbSet<AssociationFee>>();
            dbSet.As<IQueryable<AssociationFee>>().Setup(x => x.Provider).Returns(dataPruebaListadaLibros.Provider);
            dbSet.As<IQueryable<AssociationFee>>().Setup(x => x.Expression).Returns(dataPruebaListadaLibros.Expression);
            dbSet.As<IQueryable<AssociationFee>>().Setup(x => x.ElementType).Returns(dataPruebaListadaLibros.ElementType);
            dbSet.As<IQueryable<AssociationFee>>().Setup(x => x.GetEnumerator()).Returns(dataPruebaListadaLibros.GetEnumerator());

            //Asynchronous behavior
            dbSet.As<IAsyncEnumerable<AssociationFee>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<AssociationFee>(dataPruebaListadaLibros.GetEnumerator()));

            //This one allows to do filters
            dbSet.As<IQueryable<AssociationFee>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<AssociationFee>(dataPruebaListadaLibros.Provider));

            var bidCalculationDbContext = new Mock<BidCalculationDbContext>();
            bidCalculationDbContext.Setup(x => x.AssociationFees).Returns(dbSet.Object);
            return bidCalculationDbContext;
        }

        [Fact]
        public async void GetAllAssociationFee()
        {
            //Arrange
            var mockContext = ConfigurationBidCalculationDbContext();
            var mockIMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperTest());
            });
            var mockIMapper = mockIMapperConfig.CreateMapper();
            var associationFee = new AssociationFeeService(mockContext.Object, mockIMapper);

            //Act
            var listAssociationFee = await associationFee.GetAllAssociationFeesAsync();

            //Assert
            Assert.NotNull(listAssociationFee.Data);
            Assert.True(listAssociationFee.Data.Any());
            Assert.IsType<ServiceResponse<List<AssociationFeeDto>>>(listAssociationFee);
        }
    }
}