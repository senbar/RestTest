using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestTest.Api.Presenters;
using RestTest.Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using RestTest.Core.Dto.UseCaseRequests;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace RestTest.Api.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompaniesController
    {
        private readonly IAddCompanyUseCase _addCompanyUseCase;
        private readonly AddCompanyPresenter _addCompanyPresenter;

        private readonly IUpdateCompanyUseCase _updateCompanyUseCase;
        private readonly UpdateCompanyPresenter _updateCompanyPresenter;

        private readonly ISearchCompanyUseCase _searchCompanyUseCase;
        private readonly SearchCompanyPresenter _searchCompanyPresenter;

        private readonly IDeleteCompanyUseCase _deleteCompanyUseCase;
        private readonly DeleteCompanyPresenter _deleteCompanyPresenter;

        private readonly IMapper _mapper;

        public CompaniesController(IAddCompanyUseCase addCompanyUseCase, AddCompanyPresenter addCompanyPresenter,
            IUpdateCompanyUseCase updateCompanyUseCase, UpdateCompanyPresenter updateCompanyPresenter,
            ISearchCompanyUseCase searchCompanyUseCase, SearchCompanyPresenter searchCompanyPresenter,
            IDeleteCompanyUseCase deleteCompanyUseCase, DeleteCompanyPresenter deleteCompanyPresenter,
            IMapper mapper)
        {
            _mapper = mapper;

            _addCompanyUseCase = addCompanyUseCase;
            _addCompanyPresenter = addCompanyPresenter;

            _updateCompanyUseCase = updateCompanyUseCase;
            _updateCompanyPresenter = updateCompanyPresenter;

            _searchCompanyUseCase = searchCompanyUseCase;
            _searchCompanyPresenter = searchCompanyPresenter;

            _deleteCompanyUseCase = deleteCompanyUseCase;
            _deleteCompanyPresenter = deleteCompanyPresenter;

        }

#if !DEBUG
        [Authorize]
#endif
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Post([FromBody] Models.Request.AddUpdateCompanyRequest addCompanyRequest)
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

#if !DEBUG
        [Authorize]
#endif
        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult> Post(int id, [FromBody] Models.Request.AddUpdateCompanyRequest updateCompanyRequest)
        {
            var dtoRequest = _mapper.Map<Core.Dto.UseCaseRequests.UpdateCompanyRequest>(updateCompanyRequest);
            dtoRequest.Id = id;
            await _updateCompanyUseCase.Handle(dtoRequest, _updateCompanyPresenter);
            return _updateCompanyPresenter.ContentResult;
        }

#if !DEBUG
        [Authorize]
#endif
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            await _deleteCompanyUseCase.Handle(new DeleteCompanyRequest(id), _deleteCompanyPresenter);
            return _deleteCompanyPresenter.ContentResult;
        }
    }
}
