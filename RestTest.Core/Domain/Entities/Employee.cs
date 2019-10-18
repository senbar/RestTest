using System;
using System.Collections.Generic;
using System.Text;
using RestTest.Core.Domain.Enums;

namespace RestTest.Core.Domain.Entities
{
    public class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }

        public JobTitles JobTitle { get; }
    }
}
