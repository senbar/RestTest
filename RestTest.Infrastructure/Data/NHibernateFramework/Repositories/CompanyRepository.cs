﻿using AutoMapper;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using RestTest.Core.Domain.Entities;
using RestTest.Core.Domain.Enums;
using RestTest.Infrastructure.Data.Entities;
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
            CompanyEntity companyEntity =  _mapper.Map<CompanyEntity>(company);
            using (var tran = _session.BeginTransaction()) 
            { 
                await _session.SaveOrUpdateAsync(companyEntity);
                tran.Commit();
            }
            return (new AddCompanyResponse(companyEntity.Id, true));
        }

        private IQueryable<CompanyEntity> searchByKeyword(string keyword)
        {
                return _session.Query<Infrastructure.Data.Entities.CompanyEntity>().Where(x => 
                x.Employees.Any(
                e => e.FirstName.Contains(keyword)
                    || e.LastName.Contains(keyword)) 
                    || x.CompanyName.Contains(keyword));
        }
        private IQueryable<CompanyEntity> searchByBirthdayRange(DateTime from, DateTime to)
        {
                return _session.Query<Entities.CompanyEntity>().Where(x =>
                 x.Employees.Any(
                 e => e.DateOfBirth.Date > from.Date
                    && e.DateOfBirth.Date < to.Date));

        }
        private IQueryable<CompanyEntity> searchByTitles(ISet<JobTitles> titles)
        {
                return _session.Query<Entities.CompanyEntity>().Where(x =>
                x.Employees.Any(e => titles.Contains((JobTitles)e.JobTitle)));
        } 


        public async Task<SearchCompanyResponse> Search(SearchCompanyRequest searchRequest)
        {
            List<Entities.CompanyEntity> QueryResult;
            List<string> errors= new List<string>();

            using (var tran = _session.BeginTransaction())
            {
                IQueryable<CompanyEntity> result = _session.Query<CompanyEntity>();

                if(searchRequest.Keyword!=null)
                    result.Concat(searchByKeyword(searchRequest.Keyword));

                if(searchRequest.EmployeeDateOfBirthFrom != null && searchRequest.EmployeeDateOfBirthTo != null)
                     result.Concat(searchByBirthdayRange(searchRequest.EmployeeDateOfBirthFrom.GetValueOrDefault(),
                                                                 searchRequest.EmployeeDateOfBirthTo.GetValueOrDefault()));
                if (searchRequest.EmployeeJobTitles != null || searchRequest.EmployeeJobTitles.Count != 0)
                     result.Concat(searchByTitles(searchRequest.EmployeeJobTitles));


                QueryResult = await result.ToListAsync();
                
            }

            var domainMappedResult=_mapper.Map<List<Core.Domain.Entities.Company>>(QueryResult);
            
            return new SearchCompanyResponse(domainMappedResult,true);
        }

        public async Task<UpdateCompanyResponse> Update(int id, Company modifiedCompany)
        {
            CompanyEntity modifiedCompanyEntity = _mapper.Map<CompanyEntity>(modifiedCompany);

            using (var tran = _session.BeginTransaction())
            {
                var companyRecord = _session.Query<CompanyEntity>().SingleOrDefault(c => c.Id == id);
                if (companyRecord == null)
                    return new UpdateCompanyResponse(new List<string> { "Id doesn't match any records" });

                companyRecord.CompanyName = modifiedCompanyEntity.CompanyName;
                companyRecord.YearEstablished = modifiedCompanyEntity.YearEstablished;

                //find employees with the same last name which i use here as key and update their info. If employee doesnt exist insert
                foreach(var modifiedEmployeeEntity in modifiedCompanyEntity.Employees)
                {
                    EmployeeEntity employeeRecord= companyRecord.Employees.SingleOrDefault(e => e.LastName == modifiedEmployeeEntity.LastName);

                    if (employeeRecord == null)
                    {
                        companyRecord.Employees.Add(modifiedEmployeeEntity);
                    }
                    else
                    {
                        employeeRecord.DateOfBirth = modifiedEmployeeEntity.DateOfBirth;
                        employeeRecord.FirstName = modifiedEmployeeEntity.FirstName;
                        employeeRecord.JobTitle = modifiedEmployeeEntity.JobTitle;
                    }

                }

                await tran.CommitAsync();
            }

            return new UpdateCompanyResponse(true);
        }
    }
}
