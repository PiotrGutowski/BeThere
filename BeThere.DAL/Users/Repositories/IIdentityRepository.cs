using BeThere.DAL.Abstract;
using BeThere.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeThere.DAL.Users.Repositories
{
    public interface IIdentityRepository : IRepository
    {
        Task<User> GetAsync(string email);
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task EditAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
