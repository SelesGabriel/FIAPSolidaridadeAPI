using FIAPSolidaridadeAPI.Services;

namespace FIAPSolidaridadeAPI.Test.ViaCep;


[Collection(nameof(ViaCepTestCollection))]
public class ViaCepServiceTests
{
    private readonly ViaCepTestFixture _fixture;
    private readonly ViaCepService _service;

    public ViaCepServiceTests(ViaCepTestFixture fixture)
    {
        _fixture = fixture;
        _service = _fixture.GetService();
    }

    [Fact(DisplayName = "ViaCepService_GetAddressAsync_ReturnWithSuccess")]
    public async Task ViaCepService_GetAddressAsync_ReturnWithSuccess()
    {
        var cep = "01310-930";

        var result = await _service.GetAddressAsync(cep);

        Assert.NotNull(result);
    }
}
