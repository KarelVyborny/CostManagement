using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostTypes;

namespace CostManagementSystem.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Cost, CostTypeReadOnlyVM>();
            //.ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Amount));
            CreateMap<CostTypeCreateVM, Cost>();
            CreateMap<CostTypeEditVM, Cost>().ReverseMap();
        }
    }
}
