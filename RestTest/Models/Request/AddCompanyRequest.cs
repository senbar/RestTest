using RestTest.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTest.Api.Models.Request
{
    public class AddCompanyRequest
    {
        public string CompanyName { get; set; }
        public int YearEstablished { get; set; }

        public IList<Employee> Employees;
    }
}
