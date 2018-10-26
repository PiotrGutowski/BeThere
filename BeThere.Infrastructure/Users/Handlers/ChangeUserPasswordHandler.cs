using BeThere.Infrastructure.Commands;
using BeThere.Infrastructure.Users.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeThere.Infrastructure.Users.Handlers
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {

        public ChangeUserPasswordHandler()
        {

        }

        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
