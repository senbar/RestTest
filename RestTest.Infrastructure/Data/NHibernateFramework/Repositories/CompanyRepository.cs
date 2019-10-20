using AutoMapper;
using NHibernate;
using RestTest.Core.Domain.Entities;
using RestTest.Core.Dto.UseCaseResponses;
using RestTest.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
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
            return (new AddCompanyResponse(1, true));
        }
    }
}
