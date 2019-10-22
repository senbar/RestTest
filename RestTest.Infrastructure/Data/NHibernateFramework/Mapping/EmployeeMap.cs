using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using RestTest.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Infrastructure.Data.NHibernateFramework.Mapping
{
    public class EmployeeMap : ClassMapping<Data.Entities.EmployeeEntity>
    {
        public EmployeeMap()
        {
            Table("Employee");

            Id(x => x.Id, map=> map.Generator(Generators.Identity));
            
            Property(c => c.FirstName);
            
            Property(c => c.LastName);
            Property(c => c.DateOfBirth);
            Property(c => c.JobTitle);
        }
    }
}
