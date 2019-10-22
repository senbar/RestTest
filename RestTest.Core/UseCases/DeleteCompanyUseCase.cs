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
    class DeleteCompanyUseCase : IDeleteCompanyUseCase
    {
         ICompanyRepository _companyRepository;
        public DeleteCompanyUseCase(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<bool> Handle(DeleteCompanyRequest deleteCompanyRequest, IOutputPort<DeleteCompanyResponse> outputPort)
        {
            var response = await _companyRepository.Delete(deleteCompanyRequest.Id);
            outputPort.Handle(response.Success ? new DeleteCompanyResponse( true) : new DeleteCompanyResponse(response.Errors));
            return response.Success;
        }
    }
}
