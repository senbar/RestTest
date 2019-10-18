using RestTest.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestTest.Core.Dto.UseCaseResponses;
using System.Net;
using Web.Api.Serialization;

namespace RestTest.Api.Presenters
{
    public class AddCompanyPresenter : IOutputPort<AddCompanyResponse>
    {
        public JsonContentResult ContentResult { get; }

        public AddCompanyPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        
        public void Handle(AddCompanyResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Id)
        }
    }
}
