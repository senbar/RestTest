using RestTest.Core.Dto.UseCaseResponses;
using RestTest.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Core.Dto.UseCaseRequests
{
    public class DeleteCompanyRequest : IUseCaseRequest<DeleteCompanyResponse>
    {
        public int Id { get; set; }
        public DeleteCompanyRequest(int id)
        {
            Id = id;
        }
    }
}
