using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Core.Dto
{
    public abstract class UseCaseResponse
    {
        public bool Success { get; }
        public string Message { get; }

        protected UseCaseResponse(bool success=false, string message = null)
        {
            Success = success;
            Message = message;

        }
    }
}
