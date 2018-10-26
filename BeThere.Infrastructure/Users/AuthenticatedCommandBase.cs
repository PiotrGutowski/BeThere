using BeThere.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure
{
    public class AuthenticatedCommandBase : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
    }
}
