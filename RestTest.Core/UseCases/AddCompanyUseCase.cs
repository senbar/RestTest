using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestTest.Core.Dto.UseCaseRequests;
using RestTest.Core.Dto.UseCaseResponses;
using RestTest.Core.Interfaces.Gateways.Repositories;
using RestTest.Core.Interfaces.UseCases;

namespace RestTest.Core.UseCases
{
    class AddCompanyUseCase : IAddCompanyUseCase
    {
        ICompanyRepository _companyRepository;

        public AddCompanyUseCase(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Handle(AddCompanyRequest message, Interfaces.IOutputPort<AddCompanyResponse> outputPort)
        {
            var response= await _companyRepository.Create(new Domain.Entities.Company(message.CompanyName, message.YearEstablished, message.Employees));
            outputPort.Handle(response.Success ? new AddCompanyResponse(response.Id, true) : new AddCompanyResponse(response.Errors));
            return response.Success;
        }
    }
}
