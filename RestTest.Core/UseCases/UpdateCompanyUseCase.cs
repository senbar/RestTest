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
    class UpdateCompanyUseCase : IUpdateCompanyUseCase
    {
        ICompanyRepository _companyRepository;
        public UpdateCompanyUseCase(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<bool> Handle(UpdateCompanyRequest message, IOutputPort<UpdateCompanyResponse> outputPort)
        {
            var response = await _companyRepository.Update(message.Id,
                new Domain.Entities.Company(message.CompanyName, message.YearEstablished, message.Employees));

            outputPort.Handle(response.Success ? new UpdateCompanyResponse(true) : new UpdateCompanyResponse(response.Errors));
            return response.Success;
        }
    }
}
