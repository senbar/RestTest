using Autofac;
using RestTest.Core.Interfaces.Gateways.Repositories;
using RestTest.Infrastructure.Data.NHibernateFramework.Repositories;

namespace RestTest.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //TODO
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();
        }
    }
}
