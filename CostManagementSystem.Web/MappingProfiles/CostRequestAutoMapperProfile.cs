using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostRequests;

namespace CostManagementSystem.Web.MappingProfiles
{
    public class CostRequestAutoMapperProfile : Profile
    {
        public CostRequestAutoMapperProfile()
        {

            CreateMap<CostRequestCreateVM, CostRequest>();
           // CreateMap<CostRequest, EmployeeCostRequestListVM>();
          //  CreateMap<CostRequest, ReviewCostRequestVM>();


         
        }
    }

}
