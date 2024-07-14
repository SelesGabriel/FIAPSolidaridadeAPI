using FIAPSolidaridadeAPI.Controllers;
using FIAPSolidaridadeAPI.DTOs;
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

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "ModalitiesController_GetModalityById_ReturnWithSuccess")]
    public async Task ModalitiesController_GetModalityById_ReturnWithSuccess()
    {
        var modalitiesDTO = _fixture.GenerateModalitiesDTO(1).FirstOrDefault();

        _fixture.ModalityServiceMock?
            .Setup(m => m.GetModalityByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(modalitiesDTO!);

        var result = await _controller.GetModalityById(It.IsAny<int>());

        Assert.NotNull(result);
    }


    [Fact(DisplayName = "ModalitiesController_CreateModality_ReturnWithSuccess")]
    public async Task ModalitiesController_CreateModality_ReturnWithSuccess()
    {
        var modalitiesDTO = _fixture.GenerateModalitiesDTO(1).FirstOrDefault();

        _fixture.ModalityServiceMock?
            .Setup(m => m.CreateModalityAsync(It.IsAny<ModalityDTO>()))
            .ReturnsAsync(modalitiesDTO!);

        var result = await _controller.CreateModality(It.IsAny<ModalityDTO>());

        Assert.NotNull(result);
    }


    [Fact(DisplayName = "ModalitiesController_UpdateModality_ReturnWithSuccess")]
    public async Task ModalitiesController_UpdateModality_ReturnWithSuccess()
    {
        var modalityDTO = _fixture.GenerateModalitiesDTO(1).FirstOrDefault();

        _fixture.ModalityServiceMock?
            .Setup(m => m.UpdateModalityAsync(It.IsAny<int>(), It.IsAny<ModalityDTO>()))
            .ReturnsAsync(modalityDTO!);

        var result = await _controller.UpdateModality(It.IsAny<int>(), It.IsAny<ModalityDTO>());

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "ModalitiesController_DeleteModality_ReturnWithSuccess")]
    public async Task ModalitiesController_DeleteModality_ReturnWithSuccess()
    {
        _fixture.ModalityServiceMock?
            .Setup(m => m.DeleteModalityAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var result = await _controller.DeleteModality(It.IsAny<int>());

        Assert.NotNull(result);
    }
}
