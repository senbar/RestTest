using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
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

                        //since it's simple example i leave connection string as plaintext here
                        c.ConnectionString = "Data Source = RestTestDb.sqlite";
                        c.LogSqlInConsole = true;
                        c.LogFormattedSql = true;

                    });
                    if (!File.Exists("RestTestDb.sqlite"))
                        new SchemaExport(configuration).Create(true, true);
                    _sessionFactory = configuration.BuildSessionFactory();
                }


                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static void CreateDb(string connectionString)
        {
        }
    }
}
