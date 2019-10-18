using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestTest.Core.Interfaces.UseCases;

namespace RestTest.Core.UseCases
{
    class AddCompanyUseCase : IAddCompanyUseCase
    {
        public Task<bool> Handle(AddCompanyRequest message, Interfaces.IOutputPort<AddCompanyResponse> outputPort)
        {
            throw new NotImplementedException();
        }
    }
}
