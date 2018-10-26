using BeThere.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Users.Commands
{
    public class ChangeUserPassword : ICommand
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
