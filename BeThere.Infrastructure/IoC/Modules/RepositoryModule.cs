using Autofac;
//using BeThere.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BeThere.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<DAL.Abstract.IRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();


        }
    }
}