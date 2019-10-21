using RestTest.Core.Domain.Entities;
using RestTest.Core.Dto.UseCaseRequests;
using RestTest.Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestTest.Core.Interfaces.Gateways.Repositories
{
    public interface ICompanyRepository
    {
        Task<AddCompanyResponse> Create(Company company);
        Task<SearchCompanyResponse> Search(SearchCompanyRequest searchRequest);

        //TODO rest of them
    }
}
