using AutoMapper;
using CostManagementSystem.Application.Models.CostCodes;

namespace CostManagementSystem.Application.MappingProfiles
{
    public class CostCodeAutoMapperProfile : Profile
    {
        public CostCodeAutoMapperProfile()
        {
            CreateMap<CostCode, CostCodeReadOnlyVM>();
            CreateMap<CostCodeCreateVM, CostCode>();
            CreateMap<CostCodeEditVM, CostCode>().ReverseMap();


            //CreateMap<Cost, CostReadOnlyVM>();
            ////.ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Amount));
            //CreateMap<CostCreateVM, Cost>();
            //CreateMap<CostEditVM, Cost>().ReverseMap();
        }
    }


}
