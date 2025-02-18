using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Models.CostCodes;
using CostManagementSystem.Web.Models.Employee;
using CostManagementSystem.Web.Models.Period;
using CostManagementSystem.Web.Models.Project;

namespace CostManagementSystem.Web.MappingProfiles
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
