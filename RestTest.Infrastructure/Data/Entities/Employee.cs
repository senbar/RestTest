using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestTest.Core.Domain.Enums;k

namespace RestTest.Infrastructure.Data.Entities
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public JobTitles JobTitle { get; set; }
    }
}
