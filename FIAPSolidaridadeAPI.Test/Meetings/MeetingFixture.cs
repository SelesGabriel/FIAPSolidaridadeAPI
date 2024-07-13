using AutoMoqCore;
using Bogus;
using FIAPSolidaridadeAPI.Data;
using FIAPSolidaridadeAPI.DTOs;
using FIAPSolidaridadeAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FIAPSolidaridadeAPI.Test.Meetings;

[CollectionDefinition(nameof(MeetingTestCollection))]
public class MeetingTestCollection : ICollectionFixture<MeetingTestFixture> { }

public class MeetingTestFixture
{
    public Mock<IMeetingService>? MeetingServiceMock { get; set; }
    public DatabaseContext? Context { get; set; }

    public IMeetingService GetService()
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseInMemoryDatabase("Mock");
        Context = new DatabaseContext(optionsBuilder.Options);

        var mocker = new AutoMoqer();

        MeetingServiceMock = mocker.GetMock<IMeetingService>();

        return new MeetingService(Context);
    }

    public List<MeetingDTO> GenerateMeetingDTO(int quantity = 1)
    {
        return new Faker<MeetingDTO>()
            .CustomInstantiator(f => new MeetingDTO()
            {
                Date = DateTime.Now,
                DurationMinutes = 0,
                Id = f.Random.Int(),
                Location = f.Random.String()
            })
            .Generate(quantity);
    }


    public List<Meeting> GenerateMeeting(int quantity = 1)
    {
        return new Faker<Meeting>()
            .CustomInstantiator(f => new Meeting()
            {
                Date = DateTime.Now,
                DurationMinutes = 0,
                Id = f.Random.Int(),
                Location = f.Random.String()
            })
            .Generate(quantity);
    }
}
