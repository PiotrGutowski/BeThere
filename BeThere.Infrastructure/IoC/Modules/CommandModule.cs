using Autofac;
using BeThere.Infrastructure.Commands;
using BeThere.Infrastructure.Users;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BeThere.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(Commands.ICommandHandler<>))
                .InstancePerLifetimeScope();


            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();

        }
    }
}