using BeThere.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Authentication.Extensions
{
    public static class JwtExtension
    {
        public static void ConfiguredJwt(this IServiceCollection services)
        {

            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            var jwtSettings = configuration.GetOptions<JwtSettings>("jwt");
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(cfg =>
           {
               cfg.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidIssuer = jwtSettings.Issuer,
                   ValidateAudience = false,
                   IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.Key))
               };
           });


        }
    }
}

