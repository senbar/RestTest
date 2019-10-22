using RestTest.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestTest.Core.Dto.UseCaseResponses;
using System.Net;
using RestTest.Api.Serialization;

namespace RestTest.Api.Presenters
{
    public class UpdateCompanyPresenter : IOutputPort<UpdateCompanyResponse>
    {
        public JsonContentResult ContentResult { get; }

        public UpdateCompanyPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        
        public void Handle(UpdateCompanyResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? null : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
