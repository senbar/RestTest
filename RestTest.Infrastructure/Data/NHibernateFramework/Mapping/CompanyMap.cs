using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;
using RestTest.Core.Domain.Entities;

namespace RestTest.Infrastructure.Data.NHibernateFramework.Mapping
{
    public class CompanyMap : ClassMapping<Data.Entities.Company>
    {
        public CompanyMap()
        {
            Table("Company");
            Id(x => x.CompanyName);
            //Property(x => x.CompanyName);
            Property(x => x.YearEstablished);
            List(x => x.Employees, m => m.Table("Employee"), map => map.OneToMany(p => p.Class(typeof(Data.Entities.Employee))));
        }
    }
}
