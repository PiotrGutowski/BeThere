using BeThere.DAL.Abstract;
using BeThere.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeThere.DAL.Users.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {

        private readonly BeThereDbContext _db;

        public IdentityRepository(BeThereDbContext beThereDbContext)
        {
            _db = beThereDbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetAsync(string email)
        {
            return await _db.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _db.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

        }

        public async Task EditAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetAsync(id);
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

        }


    }
}
