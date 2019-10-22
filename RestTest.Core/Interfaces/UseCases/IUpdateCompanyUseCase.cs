using System;
using System.Collections.Generic;
using System.Text;
using RestTest.Core.Dto.UseCaseRequests;
using RestTest.Core.Dto.UseCaseResponses;

namespace RestTest.Core.Interfaces.UseCases
{
    public interface IUpdateCompanyUseCase : IUseCaseRequestHandler<UpdateCompanyRequest, UpdateCompanyResponse>
    {
    }
}
