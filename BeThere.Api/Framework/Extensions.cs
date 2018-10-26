using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeThere.Api.Framework
{
    public static class Extensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
           => builder.UseMiddleware(typeof(ExceptionHandlerMiddleware));
    }
}
