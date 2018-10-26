using BeThere.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Users.Commands
{
    public class SignIn : ICommand
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
