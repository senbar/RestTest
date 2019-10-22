using RestTest.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTest.Api.Models.Request
{
    public class SearchCompanyRequest
    {
        public string Keyword { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public ISet<JobTitles> EmployeeJobTitles { get; set; }

    }
}
