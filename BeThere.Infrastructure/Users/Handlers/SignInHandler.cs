using BeThere.Infrastructure.Authentication;
using BeThere.Infrastructure.Commands;
using BeThere.Infrastructure.Extensions;
using BeThere.Infrastructure.Users.Commands;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeThere.Infrastructure.Users.Handlers
{
    public class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public SignInHandler(IIdentityService identityService, IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _identityService = identityService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(SignIn command)
        {
            await _identityService.LoginAsync(command.Email, command.Password);
            var user = await _identityService.GetAsync(command.Email);
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            _cache.SetJwt(command.TokenId, jwt);
        }
    }
}
