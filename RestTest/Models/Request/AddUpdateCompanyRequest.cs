using RestTest.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestTest.Api.Models.Request
{
    public class AddUpdateCompanyRequest
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public int? YearEstablished { get; set; }


        public IList<AddEmployeeRequest> EmployeesRequest { get; set; }
    }
}
