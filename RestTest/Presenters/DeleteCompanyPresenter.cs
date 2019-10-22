using RestTest.Api.Serialization;
using RestTest.Core.Dto.UseCaseResponses;
using RestTest.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RestTest.Api.Presenters
{
    public class DeleteCompanyPresenter : IOutputPort<DeleteCompanyResponse>
    {
        public JsonContentResult ContentResult { get; }
        public DeleteCompanyPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(DeleteCompanyResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? null : JsonSerializer.SerializeObject(response.Errors);

        }
    }
}
