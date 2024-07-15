using AutoMoqCore;
using Bogus;
using FIAPSolidaridadeAPI.Data;
using FIAPSolidaridadeAPI.DTOs;
using FIAPSolidaridadeAPI.Models;
using FIAPSolidaridadeAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FIAPSolidaridadeAPI.Test.Users;

[CollectionDefinition(nameof(UsersTestCollection))]
public class UsersTestCollection : ICollectionFixture<UsersTestFixture> { }

public class UsersTestFixture
{
    public Mock<IUserService>? IUserServiceMock { get; set; }
    public AddressService? AddressService { get; set; }
    public ViaCepService? ViaCepService { get; set; }
    public DatabaseContext? Context { get; set; }

    public Mock<ViaCepService>? ViaCepServiceMock { get; set; }

    public IUserService GetService()
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseInMemoryDatabase("Mock");
        Context = new DatabaseContext(optionsBuilder.Options);

        var mocker = new AutoMoqer();

        IUserServiceMock = mocker.GetMock<IUserService>();
        ViaCepService = new ViaCepService(new HttpClient());
        AddressService = new AddressService(null, ViaCepService);

        return new UserService(Context, AddressService);
    }

    public List<UserDTO> GenerateUsersDTO(int quantity = 1)
    {
        return new Faker<UserDTO>()
            .CustomInstantiator(f => new UserDTO()
            {
                Id = f.Random.Int(),
                Name = f.Person.FirstName,
                Areas = new string[1],
                Cep = "01310-930",
                Email = f.Person.Email,
                Password = f.Random.String(8),
                Phone = f.Phone.PhoneNumber()
            })
            .Generate(quantity);
    }


    public List<User> GenerateUsers(int quantity = 1)
    {
        return new Faker<User>()
            .CustomInstantiator(f => new User()
            {
                Id = f.Random.Int(),
                Name = f.Person.FirstName,
                Areas = new string[1],
                Cep = f.Random.Int(8).ToString(),
                Email = f.Person.Email,
                Password = f.Random.String(8),
                Phone = f.Phone.PhoneNumber(),
                Region = f.Random.String()
            })
            .Generate(quantity);
    }
}
