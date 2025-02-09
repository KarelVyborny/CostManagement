using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.LeaveTypes;

namespace CostManagementSystem.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Cost, LeaveTypeReadOnlyVM>();
            //.ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Amount));
            CreateMap<LeaveTypeCreateVM, Cost>();
            CreateMap<LeaveTypeEditVM, Cost>().ReverseMap();
        }
    }
}
