using RestTest.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Core.Dto.UseCaseResponses
{
    public class SearchCompanyResponse : UseCaseResponse
    {
        public IList<Company> Result { get; }
        public IEnumerable<string> Errors { get; }

        public SearchCompanyResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public SearchCompanyResponse(IList<Company> result, bool success = false, string message = null) : base(success, message)
        {
            Result = result;
        }
    }
}
