using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Models.CostCodes;
using CostManagementSystem.Web.Models.CostRequests;
using CostManagementSystem.Web.Models.CostRequestStatuses;
using CostManagementSystem.Web.Models.Employee;
using CostManagementSystem.Web.Models.Period;
using CostManagementSystem.Web.Models.Project;

namespace CostManagementSystem.Web.MappingProfiles
{
    public class CostRequestAutoMapperProfile : Profile
    {
        public CostRequestAutoMapperProfile()
        {
            CreateMap<CostRequestCreateVM, CostRequest>();
            // CreateMap<CostRequest, EmployeeCostRequestListVM>();
            //  CreateMap<CostRequest, ReviewCostRequestVM>();
            CreateMap<CostRequest, CostRequestReadOnlyVM>();
            CreateMap<Employee, EmployeeVM>();
            CreateMap<Period, PeriodVM>();
            CreateMap<Project, ProjectVM>();
            CreateMap<CostCode, CostCodeReadOnlyVM>();
            CreateMap<CostRequestCreateVM, CostRequest>();
            CreateMap<CostRequestStatus,CostRequestStatusVM>();
        }
    }

}
