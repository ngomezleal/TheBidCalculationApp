using AutoMapper;
using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Models;

namespace BidCalculation.Tests.GenericMethods
{
    internal class MapperTest : Profile
    {
        public MapperTest()
        {
            CreateMap<AssociationFee, AssociationFeeDto>().ReverseMap();
        }
    }
}
