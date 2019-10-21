using RestTest.Core.Dto.UseCaseRequests;
using RestTest.Core.Dto.UseCaseResponses;
using RestTest.Core.Interfaces;
using RestTest.Core.Interfaces.Gateways.Repositories;
using RestTest.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestTest.Core.UseCases
{
    class SearchCompanyUseCase : ISearchCompanyUseCase
    {
        ICompanyRepository _companyRepository;
        public SearchCompanyUseCase(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<bool> Handle(SearchCompanyRequest message, IOutputPort<SearchCompanyResponse> outputPort)
        {
            var response = await _companyRepository.Search(message);
            outputPort.Handle(response.Success ? new SearchCompanyResponse(response.Result, true) : new SearchCompanyResponse(response.Errors));
            return response.Success;
        }
    }
}
