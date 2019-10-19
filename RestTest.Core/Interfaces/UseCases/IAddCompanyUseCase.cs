using RestTest.Core.Dto.UseCaseRequests;
using RestTest.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Core.Interfaces.UseCases
{
    public interface IAddCompanyUseCase : IUseCaseRequestHandler <AddCompanyRequest, AddCompanyResponse>
    {
    }
}
