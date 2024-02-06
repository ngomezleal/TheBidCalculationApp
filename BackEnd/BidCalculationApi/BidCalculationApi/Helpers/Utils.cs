using AutoMapper;
using BidCalculation.Domain.Dtos;
using BidCalculation.Domain.Models;

namespace BidCalculationApi.Helpers
{
    public class Utils: Profile
    {
        public Utils()
        {
            CreateMap<AssociationFeeDto, AssociationFee>().ReverseMap();
            CreateMap<SellerSpecialFeeDto, SellerSpecialFee>().ReverseMap();
            CreateMap<VehicleTypeDto, VehicleType>().ReverseMap();
        }
    }
}
