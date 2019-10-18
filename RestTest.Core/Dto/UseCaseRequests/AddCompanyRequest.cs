using System.Collections.Generic;
using RestTest.Core.Interfaces;
using RestTest.Core.Domain.Entities;
using RestTest.Core.Dto.UseCaseResponses;

namespace RestTest.Core.Dto.UseCaseRequests
{
    public class AddCompanyRequest : IUseCaseRequest<AddCompanyResponse>
    {
        public string CompanyName { get; }        
        public int YearEstablished { get; }
        public IEnumerable<Employee> Employees { get; }

        public AddCompanyRequest(string companyName, int yearEstablished, IEnumerable<Employee> employees)
        {
            CompanyName = companyName;
            YearEstablished = yearEstablished;
            Employees = employees;
        }
    }
}
