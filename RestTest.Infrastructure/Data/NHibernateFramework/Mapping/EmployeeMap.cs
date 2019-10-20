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
            Property(c => c.FirstName);
            Property(c => c.LastName);
            Property(c => c.JobTitle);
        }
    }
}
