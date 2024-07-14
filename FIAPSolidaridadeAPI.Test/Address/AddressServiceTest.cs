using FIAPSolidaridadeAPI.Services;

namespace FIAPSolidaridadeAPI.Test.Address;

[Collection(nameof(AddressTestCollection))]
public class AddressServiceTest
{
    private readonly AddressTestFixture _fixture;
    private readonly AddressService _service;

    public AddressServiceTest(AddressTestFixture fixture)
    {
        _fixture = fixture;
        _service = _fixture.GetService();
    }

    [Fact(DisplayName = "AddressService_GetAddressByCepAsync_ReturnWithSuccess")]
    public async Task AddressService_GetAddressByCepAsync_ReturnWithSuccess()
    {
        var cep = "01310-930";

        var result = await _service.GetAddressByCepAsync(cep);

        Assert.NotNull(result);
    }
}
