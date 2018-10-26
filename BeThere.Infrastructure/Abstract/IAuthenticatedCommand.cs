using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Abstract
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
