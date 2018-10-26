using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Users.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
    }
}
