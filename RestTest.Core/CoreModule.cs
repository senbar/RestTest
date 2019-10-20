﻿using Autofac;
using RestTest.Core.Interfaces.UseCases;
using RestTest.Core.UseCases;

namespace RestTest.Core
{
    class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddCompanyUseCase>().As<IAddCompanyUseCase>().InstancePerLifetimeScope();
        }
    }
}
