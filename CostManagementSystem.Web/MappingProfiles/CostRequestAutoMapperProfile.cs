using AutoMapper;
using CostManagementSystem.Application.Models.CostCodes;
using CostManagementSystem.Application.Models.CostRequests;
using CostManagementSystem.Application.Models.CostRequestStatuses;
using CostManagementSystem.Application.Models.Employee;
using CostManagementSystem.Application.Models.Period;
using CostManagementSystem.Application.Models.Projects;

namespace CostManagementSystem.Application.MappingProfiles
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
            CreateMap<CostRequestStatus, CostRequestStatusVM>();
        }
    }

}
