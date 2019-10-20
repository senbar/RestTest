using System.Collections.Generic;
using RestTest.Core.Domain.Enums;

namespace RestTest.Infrastructure.Data.Entities
{
    //since this example is so simple entities in this layer are the exact same entitites as in domain layer but want to keep things clean so i am still using 
    //this model
    public class Company
    {

        public virtual string CompanyName { get; set; }
        public virtual int YearEstablished { get; set; }

        public virtual IList<Employee> Employees { get; set; }

        public Company()
        {
            Employees = new List<Employee>();
        }
    }
}
