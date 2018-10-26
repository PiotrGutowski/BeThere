using BeThere.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Users.Commands
{
    public class SignUp : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
