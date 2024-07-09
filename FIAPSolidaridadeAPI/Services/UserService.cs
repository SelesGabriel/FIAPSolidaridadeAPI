using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIAPSolidaridadeAPI.Data;
using FIAPSolidaridadeAPI.DTOs;
using FIAPSolidaridadeAPI.Models;
using FIAPSolidaridadeAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace FIAPSolidaridadeAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Areas = user.Areas,
                Phone = user.Phone
            });
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Areas = user.Areas,
                Phone = user.Phone
            };
        }

        public async Task<List<UserDTO>> GetUsersByAreaAsync(string area)
        {
            var users = await _context.Users
                                      .Where(u => u.Areas.Contains(area))
                                      .ToListAsync();
            if (users == null || !users.Any()) return new List<UserDTO>();

            // Converte a lista de usuarios para uma lista de UserDTOs
            var userDTOs = users.Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Areas = user.Areas,
                Phone = user.Phone
            }).ToList();

            return userDTOs;
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {

            var user = new User
            {
                Phone = userDto.Phone,
                Areas = userDto.Areas,
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password // Isso deve ser atualizado para armazenar um hash de senha seguro
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Phone = user.Phone,
                Areas = user.Areas,
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UserDTO userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            // Atualize outros campos conforme necessário

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
