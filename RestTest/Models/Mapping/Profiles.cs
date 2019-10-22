using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestTest.Core.Dto.UseCaseRequests;
using RestTest.Core.Domain.Entities;

namespace RestTest.Api.Models.Mapping
{
    public class RequestsProfile: Profile 
    {
        public RequestsProfile()
        {
            CreateMap<Request.AddEmployeeRequest, Employee>();
            CreateMap<IList<Request.AddUpdateCompanyRequest>, IList<Employee>>();

            CreateMap<Request.AddUpdateCompanyRequest, AddCompanyRequest>()
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.EmployeesRequest));

            CreateMap<Request.AddUpdateCompanyRequest, UpdateCompanyRequest>()
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.EmployeesRequest));

            CreateMap<Request.SearchCompanyRequest, RestTest.Core.Dto.UseCaseRequests.SearchCompanyRequest>();
        }
    }
}
