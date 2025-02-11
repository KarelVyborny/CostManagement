using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.Cost;

namespace CostManagementSystem.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Cost, CostReadOnlyVM>();
            //.ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Amount));
            CreateMap<CostCreateVM, Cost>();
            CreateMap<CostEditVM, Cost>().ReverseMap();
        }
    }
}
