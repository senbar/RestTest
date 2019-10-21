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
            CreateMap<IList<Request.AddCompanyRequest>, IList<Employee>>();
            CreateMap<Request.AddCompanyRequest, AddCompanyRequest>()
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.EmployeesRequest));

            CreateMap<Request.SearchCompanyRequest, RestTest.Core.Dto.UseCaseRequests.SearchCompanyRequest>();
        }
    }
}
