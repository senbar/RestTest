using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestTest.Api.Presenters;
using RestTest.Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using RestTest.Core.Dto.UseCaseRequests;
using AutoMapper;

namespace RestTest.Api.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompaniesController
    {
        private readonly IAddCompanyUseCase _addCompanyUseCase;
        private readonly AddCompanyPresenter _addCompanyPresenter;

        private readonly ISearchCompanyUseCase _searchCompanyUseCase;
        private readonly SearchCompanyPresenter _searchCompanyPresenter;

        private readonly IMapper _mapper;

        public CompaniesController(IAddCompanyUseCase addCompanyUseCase, AddCompanyPresenter addCompanyPresenter,
            ISearchCompanyUseCase searchCompanyUseCase, SearchCompanyPresenter searchCompanyPresenter,
            IMapper mapper)
        {
            _mapper = mapper;

            _addCompanyUseCase = addCompanyUseCase;
            _addCompanyPresenter = addCompanyPresenter;

            _searchCompanyUseCase = searchCompanyUseCase;
            _searchCompanyPresenter = searchCompanyPresenter;

        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Post([FromBody] Models.Request.AddCompanyRequest addCompanyRequest)
        {
            var dtoRequest = _mapper.Map<Core.Dto.UseCaseRequests.AddCompanyRequest>(addCompanyRequest);
            await _addCompanyUseCase.Handle(dtoRequest, _addCompanyPresenter);
            return _addCompanyPresenter.ContentResult;
        }

        [HttpPost]
        [Route("search")]
        public async Task<ActionResult> Post([FromBody] Models.Request.SearchCompanyRequest searchCompanyRequest)
        {
            var dtoRequest = _mapper.Map<Core.Dto.UseCaseRequests.SearchCompanyRequest>(searchCompanyRequest);
            await _searchCompanyUseCase.Handle(dtoRequest, _searchCompanyPresenter);
            return _searchCompanyPresenter.ContentResult;
        }
    }
}
