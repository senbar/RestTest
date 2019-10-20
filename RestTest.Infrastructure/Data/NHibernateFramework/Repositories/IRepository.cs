using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestTest.Infrastructure.Data.NHibernateFramework.Repositories
{
    //todo move it 
    public interface IRepository
    {
        void Save(object obj);
        void Delete(object obj);
        object GetById(Type objType, object objectId);
        IQueryable<Tentity> ToList<Tentity>();
    }
}
