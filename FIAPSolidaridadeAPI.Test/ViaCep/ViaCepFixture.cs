using FIAPSolidaridadeAPI.Services;

namespace FIAPSolidaridadeAPI.Test.ViaCep;

[CollectionDefinition(nameof(ViaCepTestCollection))]
public class ViaCepTestCollection : ICollectionFixture<ViaCepTestFixture> { }

public class ViaCepTestFixture()
{
    public ViaCepService GetService()
    {
        return new ViaCepService(new HttpClient());

    }
}
