using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using RestTest.Infrastructure.Data.NHibernateFramework.Mapping;

namespace RestTest.Infrastructure.Data.NHibernateFramework
{
    public static class Database
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                   
                    var mapper = new ModelMapper();
                    mapper.AddMapping(typeof(CompanyMap));
                    mapper.AddMapping(typeof(EmployeeMap));
                    configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
                    
                    configuration.DataBaseIntegration(c =>
                    {
                        c.Dialect<NHibernate.Dialect.SQLiteDialect>();
                        c.ConnectionString = "Data Source = TestDb.sqlite";
                        c.LogSqlInConsole = true;
                        c.LogFormattedSql = true;
                        
                    });

                    _sessionFactory = configuration.BuildSessionFactory();
                }


                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
