using RestTest.Core.Domain.Enums;
using RestTest.Core.Dto.UseCaseResponses;
using RestTest.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Core.Dto.UseCaseRequests
{
    public class SearchCompanyRequest : IUseCaseRequest<SearchCompanyResponse>
    {
        public string Keyword { get; set; }
        public DateTime EmployeeDateOfBirthFrom { get; set; }
        public DateTime EmployeeDateOfBirthTo { get; set; }
        public ISet<JobTitles> EmployeeJobTitles { get; set; }

    }
}
