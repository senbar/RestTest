using RestTest.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestTest.Api.Models.Request
{
    public class AddEmployeeRequest
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required]
        public JobTitles JobTitle { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

    }
}
