using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Authentication
{
    public class JwtDto
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
