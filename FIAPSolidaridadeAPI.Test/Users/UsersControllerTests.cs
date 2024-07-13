using FIAPSolidaridadeAPI.Controllers;
using FIAPSolidaridadeAPI.DTOs;
using Moq;

namespace FIAPSolidaridadeAPI.Test.Users;

[Collection(nameof(UsersTestCollection))]
public class UsersControllerTests
{
    private readonly UsersTestFixture _fixture;
    private readonly UsersController _controller;

    public UsersControllerTests(UsersTestFixture fixture)
    {
        _fixture = fixture;
        _fixture.GetService();
        _controller = new UsersController(_fixture.IUserServiceMock!.Object);
    }

    [Fact(DisplayName = "UsersController_GetAllUsers_ReturnWithSuccess")]
    public async Task UsersController_GetAllUsers_ReturnWithSuccess()
    {
        var usersDTO = _fixture.GenerateUsersDTO(2);

        _fixture.IUserServiceMock?
            .Setup(m => m.GetAllUsersAsync())
            .ReturnsAsync(usersDTO);

        var result = await _controller.GetAllUsers ();

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "UsersController_GetModalityById_ReturnWithSuccess")]
    public async Task UsersController_GetModalityById_ReturnWithSuccess()
    {
        var usersDTO = _fixture.GenerateUsersDTO(1).FirstOrDefault();

        _fixture.IUserServiceMock?
            .Setup(m => m.GetUserByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(usersDTO!);

        var result = await _controller.GetUserById(It.IsAny<int>());

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "UsersController_GetUsersByArea_ReturnWithSuccess")]
    public async Task UsersController_GetUsersByArea_ReturnWithSuccess()
    {
        var usersDTO = _fixture.GenerateUsersDTO(1);

        _fixture.IUserServiceMock?
            .Setup(m => m.GetUsersByAreaAsync(It.IsAny<string>()))
            .ReturnsAsync(usersDTO!);

        var result = await _controller.GetUsersByArea(It.IsAny<string>());

        Assert.NotNull(result);
    }


    [Fact(DisplayName = "UsersController_CreateUser_ReturnWithSuccess")]
    public async Task UsersController_CreateUser_ReturnWithSuccess()
    {
        var usersDTO = _fixture.GenerateUsersDTO(1).FirstOrDefault();

        _fixture.IUserServiceMock?
            .Setup(m => m.CreateUserAsync(It.IsAny<UserDTO>()))
            .ReturnsAsync(usersDTO!);

        var result = await _controller.CreateUser(It.IsAny<UserDTO>());

        Assert.NotNull(result);
    }


    [Fact(DisplayName = "UsersController_UpdateUser_ReturnWithSuccess")]
    public async Task UsersController_UpdateUser_ReturnWithSuccess()
    {
        var usersDTO = _fixture.GenerateUsersDTO(1).FirstOrDefault();

        _fixture.IUserServiceMock?
            .Setup(m => m.UpdateUserAsync(It.IsAny<int>(), It.IsAny<UserDTO>()))
            .ReturnsAsync(usersDTO!);

        var result = await _controller.UpdateUser(It.IsAny<int>(), It.IsAny<UserDTO>());

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "UsersController_DeleteUser_ReturnWithSuccess")]
    public async Task UsersController_DeleteUser_ReturnWithSuccess()
    {
        _fixture.IUserServiceMock?
            .Setup(m => m.DeleteUserAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var result = await _controller.DeleteUser(It.IsAny<int>());

        Assert.NotNull(result);
    }
}
