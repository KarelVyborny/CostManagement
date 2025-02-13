using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostCodes;

namespace CostManagementSystem.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
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
