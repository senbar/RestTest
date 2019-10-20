using System;
using System.Collections.Generic;
using System.Text;
using RestTest.Core.Domain.Enums;

namespace RestTest.Core.Domain.Entities
{
    public class Company
    {
        public string CompanyName { get; }
        public int YearEstablished { get; }

        public IList<Employee> Employees { get; }

        public Company(string companyName, int yearEstablished, IList<Employee> employees)
        {
            CompanyName = companyName;
            YearEstablished = yearEstablished;
            Employees = employees;
        }
    }
}
