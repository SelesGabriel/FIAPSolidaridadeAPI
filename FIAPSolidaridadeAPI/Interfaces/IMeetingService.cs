using System.Collections.Generic;
using System.Threading.Tasks;
using FIAPSolidaridadeAPI.DTOs;

namespace FIAPSolidaridadeAPI.Services
{
    public interface IMeetingService
    {
        Task<IEnumerable<MeetingDTO>> GetAllMeetingsAsync();
        Task<MeetingDTO> GetMeetingByIdAsync(int id);
        Task<MeetingDTO> CreateMeetingAsync(MeetingDTO meetingDto);
        Task<MeetingDTO> UpdateMeetingAsync(int id, MeetingDTO meetingDto);
        Task<bool> DeleteMeetingAsync(int id);
    }
}
