using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestTest.Core.Interfaces.UseCases;

namespace RestTest.Api.Controllers
{
    public class CompaniesController
    {
        private readonly IAddCompanyUseCase _addCompanyUseCase;

        public CompaniesController(IAddCompanyUseCase addCompanyUseCase)
        {
            _addCompanyUseCase = addCompanyUseCase;

        }
    }
}
