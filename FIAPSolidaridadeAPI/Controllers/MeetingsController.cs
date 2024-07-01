using Microsoft.AspNetCore.Mvc;
using FIAPSolidaridadeAPI.DTOs;
using FIAPSolidaridadeAPI.Services;

namespace FIAPSolidaridadeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingsController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeetings()
        {
            var meetings = await _meetingService.GetAllMeetingsAsync();
            return Ok(meetings);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMeetingById(int id)
        {
            var meeting = await _meetingService.GetMeetingByIdAsync(id);
            if (meeting == null)
                return NotFound();
            return Ok(meeting);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeeting([FromBody] MeetingDTO meetingDto)
        {
            var createdMeeting = await _meetingService.CreateMeetingAsync(meetingDto);
            return CreatedAtAction(nameof(GetMeetingById), new { id = createdMeeting.Id }, createdMeeting);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMeeting(int id, [FromBody] MeetingDTO meetingDto)
        {
            var updatedMeeting = await _meetingService.UpdateMeetingAsync(id, meetingDto);
            if (updatedMeeting == null)
                return NotFound();
            return Ok(updatedMeeting);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMeeting(int id)
        {
            var isDeleted = await _meetingService.DeleteMeetingAsync(id);
            if (!isDeleted)
                return NotFound();
            return NoContent();
        }
    }
}
