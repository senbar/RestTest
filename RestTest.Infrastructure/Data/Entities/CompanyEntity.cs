using System.Collections.Generic;
using RestTest.Core.Domain.Enums;

namespace RestTest.Infrastructure.Data.Entities
{
    //since this example is so simple entities in this layer are the exact same entitites as in domain layer but want to keep things clean so i am still using 
    //this model
    public class CompanyEntity
    {
        public virtual int Id { get; set; }

        public virtual string CompanyName { get; set; }
        public virtual int YearEstablished { get; set; }

        public virtual ISet<EmployeeEntity> Employees { get; set; }
    }
}
