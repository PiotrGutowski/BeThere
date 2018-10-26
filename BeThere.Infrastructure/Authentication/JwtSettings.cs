using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}
