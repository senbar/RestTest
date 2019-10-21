using RestTest.Core.Dto.UseCaseRequests;
using RestTest.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestTest.Core.Interfaces.UseCases
{
    public interface ISearchCompanyUseCase : IUseCaseRequestHandler<SearchCompanyRequest, SearchCompanyResponse>
    {
    }
}
