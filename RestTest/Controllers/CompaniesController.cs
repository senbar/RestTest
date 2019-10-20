using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestTest.Api.Presenters;
using RestTest.Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using RestTest.Core.Dto.UseCaseRequests;

namespace RestTest.Api.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompaniesController
    {
        private readonly IAddCompanyUseCase _addCompanyUseCase;
        private readonly AddCompanyPresenter _addCompanyPresenter;

        public CompaniesController(IAddCompanyUseCase addCompanyUseCase, AddCompanyPresenter addCompanyPresenter)
        {
            _addCompanyUseCase = addCompanyUseCase;
            _addCompanyPresenter = addCompanyPresenter;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Post([FromBody] Models.Request.AddCompanyRequest addCompanyRequest)
        {
            await _addCompanyUseCase.Handle(new Core.Dto.UseCaseRequests.AddCompanyRequest(addCompanyRequest.CompanyName, addCompanyRequest.YearEstablished,
                addCompanyRequest.Employees), _addCompanyPresenter);
            return _addCompanyPresenter.ContentResult;
        }
    }
}
