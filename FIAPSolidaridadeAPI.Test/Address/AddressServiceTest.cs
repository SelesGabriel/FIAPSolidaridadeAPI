using FIAPSolidaridadeAPI.Services;
using FIAPSolidaridadeAPI.Test.Meetings;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var cep = "08222-010";

        var result = await _service.GetAddressByCepAsync(cep);

        Assert.NotNull(result);
    }
}
