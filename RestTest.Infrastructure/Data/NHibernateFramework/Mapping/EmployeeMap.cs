using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Infrastructure.Data.NHibernateFramework.Mapping
{
    class EmployeeMap : ClassMapping<Data.Entities.Employee>
    {
        public EmployeeMap()
        {
            Table("Employee");

            Id(x => x.Id);
            ManyToOne(x => x.Company, map =>
             {
                 map.Column("CompanyId");
             });
            
            Property(c => c.FirstName);
            Property(c => c.LastName);
            Property(c => c.DateOfBirth);
            Property(c => c.JobTitle);
        }
    }
}
