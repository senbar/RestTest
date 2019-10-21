using System;
using System.Collections.Generic;
using System.Text;
using RestTest.Core.Domain.Enums;

namespace RestTest.Core.Domain.Entities
{
    public class Company
    {
        public string CompanyName { get; set; }
        public int YearEstablished { get; set; }

        public IList<Employee> Employees { get; set; }

        public Company (string companyName, int yearEstablished, IList<Employee> employees)
        {
            CompanyName = companyName;
            YearEstablished = yearEstablished;
            Employees = employees;
        }
        public Company()
        {
            Employees = new List<Employee>();
        }
    }
}
