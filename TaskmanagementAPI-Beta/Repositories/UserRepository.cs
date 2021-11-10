using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Models;
using TaskmanagementAPI_Beta.Repositories.Interfaces;

namespace TaskmanagementAPI_Beta.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskmanagementDbContext _context;

        public UserRepository(TaskmanagementDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Models.User>> GetAllUsers()
        {
            var result = await _context.User
                .Where(u => !u.IsDeleted)
                .ToListAsync();
            return result;
        }
        public async System.Threading.Tasks.Task<bool> CreateUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<User> GetUserByIdAsync(int id)
        { 
            var userFromDb = await _context.User
                .SingleOrDefaultAsync(t => t.UserId == id);
            if (userFromDb == null)
            {
                return null;
            }

            return userFromDb;
        }

        public async Task<bool> UpdateUserByIdAsync(int id, User user)
        {
            var userFromDb = await GetUserByIdAsync(id);
            if (userFromDb == null)
            {
                return false;
            }
            userFromDb.FirstName = user.FirstName;
            userFromDb.LastName = user.LastName;

            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var userFromDb = await _context.User.SingleOrDefaultAsync(t => t.UserId == id);
            if (userFromDb == null)
            {
                return false;
            }

            userFromDb.IsDeleted = true;
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
