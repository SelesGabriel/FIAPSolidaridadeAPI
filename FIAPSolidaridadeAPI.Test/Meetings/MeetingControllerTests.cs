using FIAPSolidaridadeAPI.Controllers;
using FIAPSolidaridadeAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;

namespace FIAPSolidaridadeAPI.Test.Meetings;

[Collection(nameof(MeetingTestCollection))]
public class MeetingControllerTests
{
    private readonly MeetingTestFixture _fixture;
    private readonly MeetingsController _controller;

    public MeetingControllerTests(MeetingTestFixture fixture)
    {
        _fixture = fixture;
        _fixture.GetService();
        _controller = new MeetingsController(_fixture.MeetingServiceMock!.Object);
    }

    [Fact(DisplayName = "MeetingController_GetAll_ReturnWithSuccess")]
    public async Task MeetingController_GetAll_ReturnWithSuccess()
    {
        var meetingsDTO = _fixture.GenerateMeetingDTO(2);

        _fixture.MeetingServiceMock?
            .Setup(m => m.GetAllMeetingsAsync())
            .ReturnsAsync(meetingsDTO);

        var result = await _controller.GetAllMeetings();

        var okResult = result as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, okResult!.StatusCode);
    }

    [Fact(DisplayName = "MeetingController_GetMeetingByIdAsync_ReturnWithSuccess")]
    public async Task MeetingController_GetMeetingByIdAsync_ReturnWithSuccess()
    {
        var meetingDTO = _fixture.GenerateMeetingDTO(1).FirstOrDefault();

        _fixture.MeetingServiceMock?
            .Setup(m => m.GetMeetingByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(meetingDTO!);

        var result = await _controller.GetMeetingById(It.IsAny<int>());
        var okResult = result as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, okResult!.StatusCode);
    }

    [Fact(DisplayName = "MeetingController_GetMeetingByIdAsync_ReturnNotFound")]
    public async Task MeetingController_GetMeetingByIdAsync_ReturnNotFound()
    {
        var result = await _controller.GetMeetingById(It.IsAny<int>());
        var notFoundResult = result as Microsoft.AspNetCore.Mvc.NotFoundResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult!.StatusCode);
    }

    [Fact(DisplayName = "MeetingController_CreateMeeting_ReturnWithSuccess")]
    public async Task MeetingController_CreateMeeting_ReturnWithSuccess()
    {
        var meetingDTO = _fixture.GenerateMeetingDTO(1).FirstOrDefault();

        _fixture.MeetingServiceMock?
            .Setup(m => m.CreateMeetingAsync(It.IsAny<MeetingDTO>()))
            .ReturnsAsync(meetingDTO!);

        var result = await _controller.CreateMeeting(It.IsAny<MeetingDTO>());

        var okResult = result as CreatedAtActionResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status201Created, okResult!.StatusCode);
    }

    [Fact(DisplayName = "MeetingController_UpdateMeeting_ReturnWithSuccess")]
    public async Task MeetingController_UpdateMeeting_ReturnWithSuccess()
    {
        var meetingDTO = _fixture.GenerateMeetingDTO(1).FirstOrDefault();

        _fixture.MeetingServiceMock?
            .Setup(m => m.UpdateMeetingAsync(It.IsAny<int>(), It.IsAny<MeetingDTO>()))
            .ReturnsAsync(meetingDTO!);

        var result = await _controller.UpdateMeeting(It.IsAny<int>(), It.IsAny<MeetingDTO>());

        var okResult = result as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, okResult!.StatusCode);
    }

    [Fact(DisplayName = "MeetingController_UpdateMeeting_ReturnNotFound")]
    public async Task MeetingController_UpdateMeeting_ReturnNotFound()
    {
        var result = await _controller.UpdateMeeting(It.IsAny<int>(), It.IsAny<MeetingDTO>());
        var notFoundResult = result as Microsoft.AspNetCore.Mvc.NotFoundResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult!.StatusCode);
    }

    [Fact(DisplayName = "MeetingController_DeleteMeeting_ReturnWithSuccess")]
    public async Task MeetingController_DeleteMeeting_ReturnWithSuccess()
    {
        _fixture.MeetingServiceMock?
            .Setup(m => m.DeleteMeetingAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var result = await _controller.DeleteMeeting(It.IsAny<int>());

        var okResult = result as NoContentResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status204NoContent, okResult!.StatusCode);
    }


    [Fact(DisplayName = "MeetingController_DeleteMeeting_ReturnNotFound")]
    public async Task MeetingController_DeleteMeeting_ReturnNotFound()
    {
        var result = await _controller.DeleteMeeting(It.IsAny<int>());

        var notFoundResult = result as Microsoft.AspNetCore.Mvc.NotFoundResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult!.StatusCode);
    }
}
