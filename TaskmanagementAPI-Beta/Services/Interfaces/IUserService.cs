using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Models.Dtos;

namespace TaskmanagementAPI_Beta.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserReadDto>> GetAllUsers();
        Task<bool> CreateUserAsync(UserCreateDto userCreateDto);
        Task<bool> DeleteUserAsync(int id);
        Task<UserReadDto> GetUserByIdAsync(int id);
        Task<bool> UpdateUserByIdAsync(int id, UserCreateDto userCreateDto);
    }
}
