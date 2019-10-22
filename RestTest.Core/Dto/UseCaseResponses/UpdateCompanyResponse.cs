using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Core.Dto.UseCaseResponses
{
    public class UpdateCompanyResponse : UseCaseResponse
    {
        public IEnumerable<string> Errors { get; }

        public UpdateCompanyResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public UpdateCompanyResponse(bool success = false, string message = null) : base(success, message)
        {
        }
    }
}
