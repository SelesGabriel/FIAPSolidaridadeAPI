using FIAPSolidaridadeAPI.Services;

namespace FIAPSolidaridadeAPI.Test.Address;

[CollectionDefinition(nameof(AddressTestCollection))]
public class AddressTestCollection : ICollectionFixture<AddressTestFixture> { }

public class AddressTestFixture
{
    private ViaCepService? ViaCep;

    public AddressService GetService()
    {
        ViaCep = new ViaCepService(new HttpClient());

        return new AddressService(null!, ViaCep);
    }
}
