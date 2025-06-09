using Faculty_Student.Application.Commons.Users;
using Faculty_Student.Application.Users.DTOs;
using Faculty_Student.Application.Users.ServiceContracts;
using Faculty_Student.Application.Users.Services;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace FacultyStudent.Tests.Services;

public class UserServicesTest
{
    private readonly Mock<IUserRepository> _mockRepo;
    private readonly IUserServices _userServices;
    private readonly Mock<ILogger<UserServices>> _mockLogger;

    public UserServicesTest()
    {
        _mockLogger = new Mock<ILogger<UserServices>>();
        _mockRepo = new Mock<IUserRepository>();
        _userServices = new UserServices(_mockRepo.Object, _mockLogger.Object);
    }





    [Fact]
    public async Task RegisterUserAsync_ShouldReturnTrue_WhenInsertSucceeds()
    {
        // arrange
        var dto = new InsertUserDto
        {
            Name = "Test UserName",
            Email = "test@test.com",
            Password = "Test Password",
            Role = UsersRoles.Faculty
        };

        _mockRepo.Setup(r => r.InsertUserAsync(It.IsAny<USERS>())).ReturnsAsync(1);

        // act 
        var result = await _userServices.RegisterUserAsync(dto);

        // assert
        Assert.True(result);



    }

    [Fact]
    public async Task ValidateUserAsync_ShouldReturnNull_WhenUserNotFound()
    {
        // arrange 
        _mockRepo.Setup(r => r.GetUserByEmailAsync("Invalid@test.com")).ReturnsAsync((USERS?)null);

        // act 
        var result = await _userServices.ValidateUserAsync("Invalid@test.com", "password");

        // assert
        Assert.Null(result);
    }


    [Fact]
    public async Task ValidateUserAsync_ShouldReturnUserDto_WhenPasswordIsCorrect()
    {
        // arrange

        var hash = new UserServices(_mockRepo.Object, _mockLogger.Object)
                        .GetType().GetMethod("HashPassword", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        .Invoke(_userServices, new object[] { "123" }) as string;

        var user = new USERS
        {
            UserId = 1,
            UserName = "Test",
            Email = "test@test.com",
            PasswordHash = hash!,
            Role = UsersRoles.Student.ToString()
        };


        _mockRepo.Setup(r => r.GetUserByEmailAsync(user.Email)).ReturnsAsync(user);

        // act 
        var result = await _userServices.ValidateUserAsync(user.Email, "123");

        // assert

        Assert.NotNull(result);
        Assert.Equal(user.Email, result?.Email);
    }




}
