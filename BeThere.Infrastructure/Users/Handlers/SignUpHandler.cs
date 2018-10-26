using BeThere.Infrastructure.Commands;
using BeThere.Infrastructure.Users.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeThere.Infrastructure.Users.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IIdentityService _identityService;


        public SignUpHandler(IIdentityService identityService)
        {
            _identityService = identityService;

        }


        public async Task HandleAsync(SignUp command)
        {
            await _identityService.RegisterAsync(Guid.NewGuid(), command.Email, command.Username, command.Password, command.Role);
        }
    }
}
