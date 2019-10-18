using System;
using System.Collections.Generic;
using System.Text;
using RestTest.Core.Domain.Enums;

namespace RestTest.Core.Domain.Entities
{
    public class Company
    {
        public string CompmanyName { get; }
        public int YearEstablished { get; }

        public IList<Employee> Employees { get; }

        public Company()
        {
            Employees = new List<Employee>();
        }
    }
}
