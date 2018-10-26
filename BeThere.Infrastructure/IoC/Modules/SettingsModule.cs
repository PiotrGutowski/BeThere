using Autofac;
using BeThere.Infrastructure.Authentication;
using BeThere.Infrastructure.Extensions;

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.IoC.Modules
{

    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterInstance(_configuration.GetOptions<JwtSettings>("jwt"))
                   .SingleInstance();
            //builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
            //       .SingleInstance();
            //builder.RegisterInstance(_configuration.GetSettings<SqlSettings>())
            //       .SingleInstance();
        }
    }
}
