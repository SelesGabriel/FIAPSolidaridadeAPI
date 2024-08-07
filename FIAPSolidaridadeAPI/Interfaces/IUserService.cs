﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FIAPSolidaridadeAPI.DTOs;

namespace FIAPSolidaridadeAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<List<UserDTO>> GetUsersByAreaAsync(string area);
        Task<List<UserDTO>> GetUsersByRegionAsync(string region);
        Task<UserDTO> CreateUserAsync(UserDTO userDto);
        Task<UserDTO> UpdateUserAsync(int id, UserDTO userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
