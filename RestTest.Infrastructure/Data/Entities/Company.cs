using System.Collections.Generic;
using RestTest.Core.Domain.Enums;

namespace RestTest.Infrastructure.Data.Entities
{
    public class Company
    {
        public string CompanyName { get; set; }
        public int YearEstablished { get; set; }

        public IList<JobTitles> Employees { get; }

        public Company()
        {
            Employees = new List<JobTitles>();
        }
    }
}
