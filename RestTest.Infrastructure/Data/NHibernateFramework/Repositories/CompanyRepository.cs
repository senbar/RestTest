using AutoMapper;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using RestTest.Core.Domain.Entities;
using RestTest.Core.Domain.Enums;
using RestTest.Core.Dto.UseCaseRequests;
using RestTest.Core.Dto.UseCaseResponses;
using RestTest.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTest.Infrastructure.Data.NHibernateFramework.Repositories
{
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly IMapper _mapper;
        private readonly ISession _session;

        public CompanyRepository(IMapper mapper)
        {
            _mapper = mapper;
            _session = Database.OpenSession();
        }

        public async Task<AddCompanyResponse> Create(Company company)
        {
            Data.Entities.Company hcompany =  _mapper.Map<Data.Entities.Company>(company);
            using (var tran = _session.BeginTransaction()) 
            { 
                await _session.SaveOrUpdateAsync(hcompany);
                tran.Commit();
            }
            return (new AddCompanyResponse(hcompany.Id, true));
        }

        public async Task<SearchCompanyResponse> Search(SearchCompanyRequest searchRequest)
        {
            SearchCompanyResponse response;
            using (var tran = _session.BeginTransaction())
            {
                var keywordResult = await (_session.Query<Infrastructure.Data.Entities.Company>().Where(x => 
                x.Employees.Any(e => e.FirstName.Contains(searchRequest.Keyword)
                || e.LastName.Contains(searchRequest.Keyword)) 
                || x.CompanyName.Contains(searchRequest.Keyword))).ToListAsync();

                var birthdayRangeResult = await (_session.Query<Entities.Company>().Where(x =>
                 x.Employees.Any(
                     e => e.DateOfBirth.Date > searchRequest.EmployeeDateOfBirthFrom.Date &&
                          e.DateOfBirth.Date < searchRequest.EmployeeDateOfBirthTo)))
                 .ToListAsync();

                var titlesResult = await (_session.Query<Entities.Company>().Where(x =>
                x.Employees.Any(e => searchRequest.EmployeeJobTitles.Contains((JobTitles)e.JobTitle)))).ToListAsync();

                response = new SearchCompanyResponse(new List<string>(), true);
            }
            return response;
        }
    }
}
