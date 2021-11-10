using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Models.Dtos;
using TaskmanagementAPI_Beta.Repositories.Interfaces;
using TaskmanagementAPI_Beta.Services.Interfaces;

namespace TaskmanagementAPI_Beta.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var result = await _userRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserReadDto>>(result);
        }

        public async Task<bool> CreateUserAsync(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<Models.User>(userCreateDto);
            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<UserReadDto> GetUserByIdAsync(int id)
        {
            var userFromRepo = await _userRepository.GetUserByIdAsync(id);

            return _mapper.Map<UserReadDto>(userFromRepo);
        }

        public async Task<bool> UpdateUserByIdAsync(int id, UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<Models.User>(userCreateDto);

            return await _userRepository.UpdateUserByIdAsync(id, user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
