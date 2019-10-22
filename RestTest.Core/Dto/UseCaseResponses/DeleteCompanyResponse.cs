using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Core.Dto.UseCaseResponses
{
    public class DeleteCompanyResponse : UseCaseResponse
    {
        public IEnumerable<string> Errors { get; }

        public DeleteCompanyResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public DeleteCompanyResponse(bool success = false, string message = null) : base(success, message)
        {
        }
    }
}
