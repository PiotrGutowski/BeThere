using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Authentication
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);

    }
}
