using FIAPSolidaridadeAPI.Controllers;
using FIAPSolidaridadeAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FIAPSolidaridadeAPI.Test.Modalities;

[Collection(nameof(ModalitiesTestCollection))]
public class ModalitiesControllerTests
{
    private readonly ModalitiesTestFixture _fixture;
    private readonly ModalitiesController _controller;

    public ModalitiesControllerTests(ModalitiesTestFixture fixture)
    {
        _fixture = fixture;
        _fixture.GetService();
        _controller = new ModalitiesController(_fixture.ModalityServiceMock!.Object);
    }

    [Fact(DisplayName = "ModalitiesController_GetAllModalities_ReturnWithSuccess")]
    public async Task ModalitiesController_GetAllModalities_ReturnWithSuccess()
    {
        var modalitiesDTO = _fixture.GenerateModalitiesDTO(2);

        _fixture.ModalityServiceMock?
            .Setup(m => m.GetAllModalitiesAsync())
            .ReturnsAsync(modalitiesDTO);

        var result = await _controller.GetAllModalities();

        var okResult = result as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, okResult!.StatusCode);
    }

    [Fact(DisplayName = "ModalitiesController_GetModalityById_ReturnWithSuccess")]
    public async Task ModalitiesController_GetModalityById_ReturnWithSuccess()
    {
        var modalitiesDTO = _fixture.GenerateModalitiesDTO(1).FirstOrDefault();

        _fixture.ModalityServiceMock?
            .Setup(m => m.GetModalityByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(modalitiesDTO!);

        var result = await _controller.GetModalityById(It.IsAny<int>());
        var okResult = result as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, okResult!.StatusCode);
    }

    [Fact(DisplayName = "ModalitiesController_GetModalityById_ReturnNotFound")]
    public async Task ModalitiesController_GetModalityById_ReturnNotFound()
    {
        var result = await _controller.GetModalityById(It.IsAny<int>());
        var notFoundResult = result as NotFoundResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult!.StatusCode);
    }


    [Fact(DisplayName = "ModalitiesController_CreateModality_ReturnWithSuccess")]
    public async Task ModalitiesController_CreateModality_ReturnWithSuccess()
    {
        var modalitiesDTO = _fixture.GenerateModalitiesDTO(1).FirstOrDefault();

        _fixture.ModalityServiceMock?
            .Setup(m => m.CreateModalityAsync(It.IsAny<ModalityDTO>()))
            .ReturnsAsync(modalitiesDTO!);

        var result = await _controller.CreateModality(It.IsAny<ModalityDTO>());

        var okResult = result as CreatedAtActionResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status201Created, okResult!.StatusCode);
    }


    [Fact(DisplayName = "ModalitiesController_UpdateModality_ReturnWithSuccess")]
    public async Task ModalitiesController_UpdateModality_ReturnWithSuccess()
    {
        var modalityDTO = _fixture.GenerateModalitiesDTO(1).FirstOrDefault();

        _fixture.ModalityServiceMock?
            .Setup(m => m.UpdateModalityAsync(It.IsAny<int>(), It.IsAny<ModalityDTO>()))
            .ReturnsAsync(modalityDTO!);

        var result = await _controller.UpdateModality(It.IsAny<int>(), It.IsAny<ModalityDTO>());

        var okResult = result as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, okResult!.StatusCode);
    }

    [Fact(DisplayName = "ModalitiesController_UpdateModality_ReturnNotFound")]
    public async Task ModalitiesController_UpdateModality_ReturnNotFound()
    {
        var result = await _controller.UpdateModality(It.IsAny<int>(), It.IsAny<ModalityDTO>());

        var notFoundResult = result as NotFoundResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult!.StatusCode);
    }

    [Fact(DisplayName = "ModalitiesController_DeleteModality_ReturnWithSuccess")]
    public async Task ModalitiesController_DeleteModality_ReturnWithSuccess()
    {
        _fixture.ModalityServiceMock?
            .Setup(m => m.DeleteModalityAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var result = await _controller.DeleteModality(It.IsAny<int>());

        var okResult = result as NoContentResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status204NoContent, okResult!.StatusCode);
    }

    [Fact(DisplayName = "ModalitiesController_DeleteModality_ReturnNotFound")]
    public async Task ModalitiesController_DeleteModality_ReturnNotFound()
    {
        var result = await _controller.DeleteModality(It.IsAny<int>());
        var notFoundResult = result as NotFoundResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult!.StatusCode);
    }
}
