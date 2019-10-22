using Autofac;
using RestTest.Core.Interfaces.UseCases;
using RestTest.Core.UseCases;

namespace RestTest.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddCompanyUseCase>().As<IAddCompanyUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<SearchCompanyUseCase>().As<ISearchCompanyUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateCompanyUseCase>().As<IUpdateCompanyUseCase>().InstancePerLifetimeScope();
        }
    }
}
