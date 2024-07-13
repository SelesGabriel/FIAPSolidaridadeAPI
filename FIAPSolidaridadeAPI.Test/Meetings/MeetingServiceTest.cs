using FIAPSolidaridadeAPI.Services;

namespace FIAPSolidaridadeAPI.Test.Meetings;

[Collection(nameof(MeetingTestCollection))]
public class MeetingServiceTest
{
    private readonly MeetingTestFixture _fixture;
    private readonly IMeetingService _service;

    public MeetingServiceTest(MeetingTestFixture fixture)
    {
        _fixture = fixture;
        _service = _fixture.GetService();
    }

    [Fact(DisplayName = "MeetingService_GetAllMeetingsAsync_ReturnWithSuccess")]
    public async Task MeetingService_GetAll_ReturnWithSuccess()
    {
        var meeting = _fixture.GenerateMeeting(2);

        await _fixture.Context!.Meetings!.AddRangeAsync(meeting!);
        await _fixture.Context.SaveChangesAsync();

        var result = await _service.GetAllMeetingsAsync();

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "MeetingService_GetMeetingByIdAsync_ReturnWithSuccess")]
    public async Task MeetingService_GetMeetingByIdAsync_ReturnWithSuccess()
    {
        var meeting = _fixture.GenerateMeeting(1).FirstOrDefault();

        await _fixture.Context!.Meetings!.AddAsync(meeting!);
        await _fixture.Context.SaveChangesAsync();

        var result = await _service.GetMeetingByIdAsync(meeting!.Id);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "MeetingService_CreateMeetingAsync_ReturnWithSuccess")]
    public async Task MeetingService_CreateMeetingAsync_ReturnWithSuccess()
    {
        var meetingDTO = _fixture.GenerateMeetingDTO(1).FirstOrDefault();

        var result = await _service.CreateMeetingAsync(meetingDTO!);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "MeetingService_UpdateMeetingAsync_ReturnWithSuccess")]
    public async Task MeetingService_UpdateMeetingAsync_ReturnWithSuccess()
    {
        var meeting = _fixture.GenerateMeeting(1).FirstOrDefault();

        await _fixture.Context!.Meetings!.AddAsync(meeting!);
        await _fixture.Context.SaveChangesAsync();

        var meetingDTO = _fixture.GenerateMeetingDTO(1).FirstOrDefault();

        var result = await _service.UpdateMeetingAsync(meeting!.Id, meetingDTO!);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "MeetingService_DeleteMeetingAsync_ReturnWithSuccess")]
    public async Task MeetingService_DeleteMeetingAsync_ReturnWithSuccess()
    {
        var meeting = _fixture.GenerateMeeting(1).FirstOrDefault();

        await _fixture.Context!.Meetings!.AddAsync(meeting!);
        await _fixture.Context.SaveChangesAsync();

        var result = await _service.DeleteMeetingAsync(meeting!.Id);

        Assert.True(result!);
    }
}
