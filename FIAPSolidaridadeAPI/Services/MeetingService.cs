using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIAPSolidaridadeAPI.Data;
using FIAPSolidaridadeAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FIAPSolidaridadeAPI.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly DatabaseContext _context;

        public MeetingService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MeetingDTO>> GetAllMeetingsAsync()
        {
            var meetings = await _context.Meetings.ToListAsync();
            return meetings.Select(meeting => new MeetingDTO
            {
                Id = meeting.Id,
                Date = meeting.Date,
                DurationMinutes = meeting.DurationMinutes,
                Location = meeting.Location
            });
        }

        public async Task<MeetingDTO> GetMeetingByIdAsync(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null) return null;

            return new MeetingDTO
            {
                Id = meeting.Id,
                Date = meeting.Date,
                DurationMinutes = meeting.DurationMinutes,
                Location = meeting.Location
            };
        }

        public async Task<MeetingDTO> CreateMeetingAsync(MeetingDTO meetingDto)
        {
            var meeting = new Meeting
            {
                Date = meetingDto.Date,
                DurationMinutes = meetingDto.DurationMinutes,
                Location = meetingDto.Location
            };

            _context.Meetings.Add(meeting);
            await _context.SaveChangesAsync();

            return new MeetingDTO
            {
                Id = meeting.Id,
                Date = meeting.Date,
                DurationMinutes = meeting.DurationMinutes,
                Location = meeting.Location
            };
        }

        public async Task<MeetingDTO> UpdateMeetingAsync(int id, MeetingDTO meetingDto)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null) return null;

            meeting.Date = meetingDto.Date;
            meeting.DurationMinutes = meetingDto.DurationMinutes;
            meeting.Location = meetingDto.Location;

            _context.Meetings.Update(meeting);
            await _context.SaveChangesAsync();

            return new MeetingDTO
            {
                Id = meeting.Id,
                Date = meeting.Date,
                DurationMinutes = meeting.DurationMinutes,
                Location = meeting.Location
            };
        }

        public async Task<bool> DeleteMeetingAsync(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null) return false;

            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
