using System;
using System.Collections.Generic;
using System.Text;
using RestTest.Core.Domain.Enums;

namespace RestTest.Core.Domain.Entities
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public JobTitles JobTitle { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
