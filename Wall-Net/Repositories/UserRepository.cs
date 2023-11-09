﻿using Microsoft.EntityFrameworkCore;
using Wall_Net.DataAccess;
using Wall_Net.Models;

namespace Wall_Net.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WallNetDbContext _dbcontext;

        public UserRepository(WallNetDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task <IEnumerable<User>> GetAll()
        {
            return await _dbcontext.Users.ToListAsync();
        }

        public async Task <User> GetById(int id)
        {
            return await _dbcontext.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(User user)
        {
            _dbcontext.Users.Add(user);
            //await _dbcontext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _dbcontext.Users.Update(user);
           // await _dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = _dbcontext.Users.FirstOrDefault(p => p.Id == id);
            if (user != null)
            {
                _dbcontext.Users.Remove(user);
                //await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
