using BeThere.Infrastructure.Abstract;
using BeThere.Infrastructure.Users.Commands;
using BeThere.Infrastructure.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeThere.Infrastructure.Users
{
    public interface IIdentityService : IService
    {
        Task<UserDto> GetAsync(string email);
        Task RegisterAsync(Guid userId, string email, string username, string hash, string role);
        Task LoginAsync(string email, string password);

    }
}
