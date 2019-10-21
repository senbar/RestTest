using System.Collections.Generic;
using RestTest.Core.Interfaces;
using RestTest.Core.Domain.Entities;
using RestTest.Core.Dto.UseCaseResponses;
using System;

namespace RestTest.Core.Dto.UseCaseRequests
{
    public class AddCompanyRequest : IUseCaseRequest<AddCompanyResponse>
    {
        public string CompanyName { get; set; }        
        public int YearEstablished { get; set; }
        public IList<Employee> Employees { get; set; }


        public AddCompanyRequest(string companyName, int yearEstablished, IList<Employee> employees)
        {
            CompanyName = companyName;
            YearEstablished = yearEstablished;
            Employees = employees;
        }
        public AddCompanyRequest()
        {
            Employees = new List<Employee>();
        }

    }
}
