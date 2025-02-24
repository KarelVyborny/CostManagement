using AutoMapper;
using CostManagementSystem.Application.Models.CostApproval;
using CostManagementSystem.Application.Models.CostCodes;
using CostManagementSystem.Application.Models.Employee;
using CostManagementSystem.Application.Models.Period;
using CostManagementSystem.Application.Models.Projects;

namespace CostManagementSystem.Application.MappingProfiles
{
    public class CostApprovalAutoMapperProfile : Profile
    {
        public CostApprovalAutoMapperProfile()
        {

            CreateMap<CostApproval, CostApprovalReadOnlyVM>();
            CreateMap<Employee, EmployeeVM>();
            CreateMap<Period, PeriodVM>();
            CreateMap<Project, ProjectVM>();
            CreateMap<CostCode, CostCodeReadOnlyVM>();
            CreateMap<CostApprovalCreateVM, CostApproval>();
            CreateMap<CostApprovalEditVM, CostApproval>().ReverseMap();

            //CreateMap<Cost, CostReadOnlyVM>();
            ////.ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Amount));
            //CreateMap<CostCreateVM, Cost>();
            //CreateMap<CostEditVM, Cost>().ReverseMap();
        }
    }

}
