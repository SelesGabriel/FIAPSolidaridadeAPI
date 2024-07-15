using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        private readonly AddressService _addressService;

        public UserService(DatabaseContext context, AddressService addressService)
        {
            _context = context;
            _addressService = addressService;
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
                Phone = user.Phone,
                Cep = user.Cep,
                Region = user.Region,
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
                Phone = user.Phone,
                Cep = user.Cep,
                Region = user.Region,
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
                Phone = user.Phone,
                Cep = user.Cep,
                Region = user.Region,
            }).ToList();

            return userDTOs;
        }

        public async Task<List<UserDTO>> GetUsersByRegionAsync(string region)
        {

            var users = await _context.Users
                                      .Where(u => u.Region.Contains(region))
                                      .ToListAsync();
            if (users == null || !users.Any()) return new List<UserDTO>();

            // Converte a lista de usuarios para uma lista de UserDTOs
            var userDTOs = users.Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Areas = user.Areas,
                Phone = user.Phone,
                Cep = user.Cep,
                Region = user.Region,
            }).ToList();

            return userDTOs;
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            var address = await _addressService.GetAddressByCepAsync(userDto.Cep);

            if (address == null)
            {
                return new UserDTO();
            }


            var user = new User
            {
                Phone = userDto.Phone,
                Areas = userDto.Areas,
                Name = userDto.Name,
                Email = userDto.Email,
                Cep = userDto.Cep,
                Region = string.Concat(address.Uf + " - " + address.Localidade),
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
                Email = user.Email,
                Cep= user.Cep,
                Region = user.Region,
            };
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UserDTO userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            var address = await _addressService.GetAddressByCepAsync(userDto.Cep);
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            // Atualize outros campos conforme necessário

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Phone = user.Phone,
                Areas = user.Areas,
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Cep = user.Cep,
                Region = string.Concat(address.Uf + " - " + address.Localidade),
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
