using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestTest.Core.Interfaces
{
    public interface IUseCaseRequestHandler<TRequest, TResponse> where TRequest : IUseCaseRequest<TResponse>
    {
        public Task<bool> Handle(TRequest message, IOutputPort<TResponse> outputPort);
    }
}
