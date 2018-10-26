using BeThere.Infrastructure.Authentication;
using BeThere.Infrastructure.Commands;
using BeThere.Infrastructure.Extensions;
using BeThere.Infrastructure.Users;
using BeThere.Infrastructure.Users.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BeThere.Api.Controllers
{
    [Route("api/identity")]
    public class IdentityController : ApiControllerBase
    {

        private readonly ICommandDispatcher _commandDispacher;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;
        private readonly ILogger<IdentityController> _logger;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public IdentityController(ICommandDispatcher commandDispacher,
            IJwtHandler jwtHandler, IMemoryCache cache, ILogger<IdentityController> logger) : base(commandDispacher)
        {
            _jwtHandler = jwtHandler;
            _commandDispacher = commandDispacher;
            _cache = cache;
            _logger = logger;
        }


        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Post([FromBody]SignUp command)
        {

            await DispatchAsync(command);

            return Created($"users/{command.Email}", null);

        }


        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> Post([FromBody]SignIn command)
        {
            Logger.Info("Sign In User");
            command.TokenId = Guid.NewGuid();

            await DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);

        }
   




    }
}
