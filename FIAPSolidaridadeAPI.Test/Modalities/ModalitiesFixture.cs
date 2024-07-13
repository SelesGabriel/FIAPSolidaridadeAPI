using AutoMoqCore;
using Bogus;
using FIAPSolidaridadeAPI.Data;
using FIAPSolidaridadeAPI.DTOs;
using FIAPSolidaridadeAPI.Models;
using FIAPSolidaridadeAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FIAPSolidaridadeAPI.Test.Modalities;

[CollectionDefinition(nameof(ModalitiesTestCollection))]
public class ModalitiesTestCollection : ICollectionFixture<ModalitiesTestFixture> { }

public class ModalitiesTestFixture
{
    public Mock<IModalityService>? ModalityServiceMock { get; set; }
    public DatabaseContext? Context { get; set; }

    public IModalityService GetService()
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseInMemoryDatabase("Mock");
        Context = new DatabaseContext(optionsBuilder.Options);

        var mocker = new AutoMoqer();

        ModalityServiceMock = mocker.GetMock<IModalityService>();

        return new ModalityService(Context);
    }

    public List<ModalityDTO> GenerateModalitiesDTO(int quantity = 1)
    {
        return new Faker<ModalityDTO>()
            .CustomInstantiator(f => new ModalityDTO()
            {
                Id = f.Random.Int(),
                Description = f.Random.String(),
                Name = f.Random.String()
            })
            .Generate(quantity);
    }


    public List<Modality> GenerateModalities(int quantity = 1)
    {
        return new Faker<Modality>()
            .CustomInstantiator(f => new Modality()
            {
                Id = f.Random.Int(),
                Description = f.Random.String(),
                Name = f.Random.String()
            })
            .Generate(quantity);
    }
}