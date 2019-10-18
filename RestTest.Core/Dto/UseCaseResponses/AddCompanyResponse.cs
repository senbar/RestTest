using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Core.Dto.UseCaseResponses
{
    public class AddCompanyResponse : UseCaseResponse
    {
        public int Id { get; }
        public IEnumerable<string> Errors { get; }

        public AddCompanyResponse(IEnumerable<string> errors, bool success= false, string message=null): base(success, message)
        {
            Errors = errors;
        }

        public AddCompanyResponse(int id, bool success = false, string message = null): base (success,message)
        {
            Id = id;
        }
    }
}
