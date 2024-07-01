using System.Collections.Generic;
using System.Threading.Tasks;
using FIAPSolidaridadeAPI.DTOs;

namespace FIAPSolidaridadeAPI.Services
{
    public interface IModalityService
    {
        Task<IEnumerable<ModalityDTO>> GetAllModalitiesAsync();
        Task<ModalityDTO> GetModalityByIdAsync(int id);
        Task<ModalityDTO> CreateModalityAsync(ModalityDTO modalityDto);
        Task<ModalityDTO> UpdateModalityAsync(int id, ModalityDTO modalityDto);
        Task<bool> DeleteModalityAsync(int id);
    }
}
