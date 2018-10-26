using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Authentication
{
    public interface IEncrypter
    {
        string GetSalt(string value);
        string GetHash(string value, string salt);
    }
}

