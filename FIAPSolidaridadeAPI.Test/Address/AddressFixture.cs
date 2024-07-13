using AutoMoqCore;
using FIAPSolidaridadeAPI.Data;
using FIAPSolidaridadeAPI.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;

namespace FIAPSolidaridadeAPI.Test.Address;

[CollectionDefinition(nameof(AddressTestCollection))]
public class AddressTestCollection : ICollectionFixture<AddressTestFixture> { }

public class AddressTestFixture
{
    private MongoDbContext MongoContext;
    private ViaCepService ViaCep;
    private Mock<HttpClient> HttpClientMock;

    private IOptions<MongoDbSettings> _mongoSettings;
    private Mock<IMongoDatabase> _fakeMongoDatabase;
    private Mock<MongoDbContext> _fakeMongoContext;
    private Mock<Models.Address> _fakeMongoCollection;

    public AddressService GetService()
    {
        var mocker = new AutoMoqer();

        var collectionMock = Mock.Of<IMongoCollection<Models.Address>>();
        var dbMock = new Mock<MongoDbContext>();
        ViaCep = new ViaCepService(new HttpClient());

        _fakeMongoDatabase = new Mock<IMongoDatabase>();
        _mongoSettings = Options.Create(new MongoDbSettings() { ConnectionString = "mongodb://localhost:27017", DatabaseName = "mock" });

        _fakeMongoContext = new Mock<MongoDbContext>(_mongoSettings);

        var _fakeMongoCollection = new Mock<IMongoCollection<Models.Address>>();

        _fakeMongoContext
            .Setup(_ => _.Addresses)
            .Returns(_fakeMongoCollection.Object);

        return new AddressService(_fakeMongoContext.Object, ViaCep);
    }
}
