using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;
using RestTest.Core.Domain.Entities;
using NHibernate.Mapping.ByCode;

namespace RestTest.Infrastructure.Data.NHibernateFramework.Mapping
{
    public class CompanyMap : ClassMapping<Data.Entities.CompanyEntity>
    {
        public CompanyMap()
        {
            Table("Company");
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.CompanyName);
            Property(x => x.YearEstablished);
            Set(x => x.Employees,
            m =>
            {
                m.Table("Employee");
                m.Cascade(Cascade.DeleteOrphans);
                m.Key(c => c.Column("CompanyId"));
            },
            map =>
            {
                map.OneToMany(p => p.Class(typeof(Data.Entities.EmployeeEntity)));
           });
            
        }
    }
}
