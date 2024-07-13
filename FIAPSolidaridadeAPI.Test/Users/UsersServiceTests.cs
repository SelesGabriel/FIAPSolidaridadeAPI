using FIAPSolidaridadeAPI.Services;
using FIAPSolidaridadeAPI.Test.Modalities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPSolidaridadeAPI.Test.Users;

[Collection(nameof(UsersTestCollection))]
public class UsersServiceTests
{
    private readonly UsersTestFixture _fixture;
    private readonly IUserService _service;

    public UsersServiceTests(UsersTestFixture fixture)
    {
        _fixture = fixture;
        _service = _fixture.GetService();
    }

    [Fact(DisplayName = "UsersService_GetAllUsersAsync_ReturnWithSuccess")]
    public async Task UsersService_GetAllUsersAsync_ReturnWithSuccess()
    {
        var users = _fixture.GenerateUsers(2);

        await _fixture.Context!.Users!.AddRangeAsync(users!);
        await _fixture.Context.SaveChangesAsync();

        var result = await _service.GetAllUsersAsync();

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "UsersService_GetUserByIdAsync_ReturnWithSuccess")]
    public async Task UsersService_GetUserByIdAsync_ReturnWithSuccess()
    {
        var user = _fixture.GenerateUsers(1).FirstOrDefault();

        await _fixture.Context!.Users!.AddAsync(user!);
        await _fixture.Context.SaveChangesAsync();

        var result = await _service.GetUserByIdAsync(user!.Id);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "UsersService_GetUsersByAreaAsync_ReturnWithSuccess")]
    public async Task UsersService_GetUsersByAreaAsync_ReturnWithSuccess()
    {
        var user = _fixture.GenerateUsers(1).FirstOrDefault();

        await _fixture.Context!.Users!.AddAsync(user!);
        await _fixture.Context.SaveChangesAsync();

        var result = await _service.GetUsersByAreaAsync(user!.Areas!.FirstOrDefault()!);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "UsersService_CreateUserAsync_ReturnWithSuccess")]
    public async Task UsersService_CreateUserAsync_ReturnWithSuccess()
    {
        var userDTO = _fixture.GenerateUsersDTO(1).FirstOrDefault();

        var result = await _service.CreateUserAsync(userDTO!);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "UsersService_UpdateUserAsync_ReturnWithSuccess")]
    public async Task UsersService_UpdateUserAsync_ReturnWithSuccess()
    {
        var user = _fixture.GenerateUsers(1).FirstOrDefault();

        await _fixture.Context!.Users!.AddAsync(user!);
        await _fixture.Context.SaveChangesAsync();

        var modalityDTO = _fixture.GenerateUsersDTO(1).FirstOrDefault();

        var result = await _service.UpdateUserAsync(user!.Id, modalityDTO!);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "UsersService_DeleteUserAsync_ReturnWithSuccess")]
    public async Task UsersService_DeleteUserAsync_ReturnWithSuccess()
    {
        var user = _fixture.GenerateUsers(1).FirstOrDefault();

        await _fixture.Context!.Users!.AddAsync(user!);
        await _fixture.Context.SaveChangesAsync();

        var result = await _service.DeleteUserAsync(user!.Id);

        Assert.True(result!);
    }
}
