using RestTest.Core.Domain.Entities;
using RestTest.Core.Dto.UseCaseResponses;
using RestTest.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Core.Dto.UseCaseRequests
{
    public class UpdateCompanyRequest : IUseCaseRequest<UpdateCompanyResponse>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int YearEstablished { get; set; }
        public IList<Employee> Employees { get; set; }


        public UpdateCompanyRequest(int id, string companyName, int yearEstablished, IList<Employee> employees)
        {
            Id = id;
            CompanyName = companyName;
            YearEstablished = yearEstablished;
            Employees = employees;
        }
        public UpdateCompanyRequest()
        {
            Employees = new List<Employee>();
        }

    }
}
