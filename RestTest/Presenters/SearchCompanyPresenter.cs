﻿using RestTest.Api.Serialization;
using RestTest.Core.Dto.UseCaseResponses;
using RestTest.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RestTest.Api.Presenters
{
    public class SearchCompanyPresenter : IOutputPort<SearchCompanyResponse>
    {
        public JsonContentResult ContentResult { get; }
        public SearchCompanyPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(SearchCompanyResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Result) : JsonSerializer.SerializeObject(response.Errors);

        }
    }
}
