using FIAPSolidaridadeAPI.Services;

namespace FIAPSolidaridadeAPI.Test.Modalities;

[Collection(nameof(ModalitiesTestCollection))]
public class ModalitiesServiceTests
{
    private readonly ModalitiesTestFixture _fixture;
    private readonly IModalityService _service;

    public ModalitiesServiceTests(ModalitiesTestFixture fixture)
    {
        _fixture = fixture;
        _service = _fixture.GetService();
    }

    [Fact(DisplayName = "ModalityService_GetAllModalitiesAsync_ReturnWithSuccess")]
    public async Task ModalityService_GetAllModalitiesAsync_ReturnWithSuccess()
    {
        var modalities = _fixture.GenerateModalities(2);

        await _fixture.Context!.Modalities!.AddRangeAsync(modalities!);
        await _fixture.Context.SaveChangesAsync();

        var result = await _service.GetAllModalitiesAsync();

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "ModalityService_GetModalityByIdAsync_ReturnWithSuccess")]
    public async Task ModalityService_GetModalityByIdAsync_ReturnWithSuccess()
    {
        var modality = _fixture.GenerateModalities(1).FirstOrDefault();

        await _fixture.Context!.Modalities!.AddAsync(modality!);
        await _fixture.Context.SaveChangesAsync();

        var result = await _service.GetModalityByIdAsync(modality!.Id);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "ModalityService_CreateModalityAsync_ReturnWithSuccess")]
    public async Task ModalityService_CreateModalityAsync_ReturnWithSuccess()
    {
        var modalityDTO = _fixture.GenerateModalitiesDTO(1).FirstOrDefault();

        var result = await _service.CreateModalityAsync(modalityDTO!);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "ModalityService_UpdateModalityAsync_ReturnWithSuccess")]
    public async Task ModalityService_UpdateModalityAsync_ReturnWithSuccess()
    {
        var modality = _fixture.GenerateModalities(1).FirstOrDefault();

        await _fixture.Context!.Modalities!.AddAsync(modality!);
        await _fixture.Context.SaveChangesAsync();

        var modalityDTO = _fixture.GenerateModalitiesDTO(1).FirstOrDefault();

        var result = await _service.UpdateModalityAsync(modality!.Id, modalityDTO!);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "ModalityService_DeleteModalityAsync_ReturnWithSuccess")]
    public async Task ModalityService_DeleteModalityAsync_ReturnWithSuccess()
    {
        var modality = _fixture.GenerateModalities(1).FirstOrDefault();

        await _fixture.Context!.Modalities!.AddAsync(modality!);
        await _fixture.Context.SaveChangesAsync();

        var result = await _service.DeleteModalityAsync(modality!.Id);

        Assert.True(result!);
    }
}
