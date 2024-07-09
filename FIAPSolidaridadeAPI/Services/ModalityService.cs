using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIAPSolidaridadeAPI.Data;
using FIAPSolidaridadeAPI.DTOs;
using FIAPSolidaridadeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FIAPSolidaridadeAPI.Services
{
    public class ModalityService : IModalityService
    {
        private readonly DatabaseContext _context;

        public ModalityService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ModalityDTO>> GetAllModalitiesAsync()
        {
            var modalities = await _context.Modalities.ToListAsync();
            return modalities.Select(modality => new ModalityDTO
            {
                Id = modality.Id,
                Name = modality.Name,
                Description = modality.Description
            });
        }

        public async Task<ModalityDTO> GetModalityByIdAsync(int id)
        {
            var modality = await _context.Modalities.FindAsync(id);
            if (modality == null) return null;

            return new ModalityDTO
            {
                Id = modality.Id,
                Name = modality.Name,
                Description = modality.Description
            };
        }

        public async Task<ModalityDTO> CreateModalityAsync(ModalityDTO modalityDto)
        {
            var modality = new Modality
            {
                Name = modalityDto.Name,
                Description = modalityDto.Description
            };

            _context.Modalities.Add(modality);
            await _context.SaveChangesAsync();

            return new ModalityDTO
            {
                Id = modality.Id,
                Name = modality.Name,
                Description = modality.Description
            };
        }

        public async Task<ModalityDTO> UpdateModalityAsync(int id, ModalityDTO modalityDto)
        {
            var modality = await _context.Modalities.FindAsync(id);
            if (modality == null) return null;

            modality.Name = modalityDto.Name;
            modality.Description = modalityDto.Description;

            _context.Modalities.Update(modality);
            await _context.SaveChangesAsync();

            return new ModalityDTO
            {
                Id = modality.Id,
                Name = modality.Name,
                Description = modality.Description
            };
        }

        public async Task<bool> DeleteModalityAsync(int id)
        {
            var modality = await _context.Modalities.FindAsync(id);
            if (modality == null) return false;

            _context.Modalities.Remove(modality);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
