using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Models;

namespace TaskmanagementAPI_Beta.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsers();
        System.Threading.Tasks.Task<bool> CreateUserAsync(Models.User user);
        Task<bool> DeleteUserAsync(int id);
        Task<Models.User> GetUserByIdAsync(int id);
        Task<bool> UpdateUserByIdAsync(int id, Models.User user);
    }
}
