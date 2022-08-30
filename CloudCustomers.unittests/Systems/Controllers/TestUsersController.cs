namespace CloudCustomers.unittests.Systems.Controllers;
using CloudCustomers.api.Controllers;
using CloudCustomers.api.Services;
using CloudCustomers.unittests.Fixtures;
using CloudCustomers.api.Models;
using FluentAssertions;
using Moq;
using Microsoft.AspNetCore.Mvc;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers());

        var systemUnderTest = new UsersController(mockUserService.Object);
         
        //Act
        var result = (OkObjectResult)await systemUnderTest.Get();

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceOnce()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var systemUnderTest = new UsersController(mockUserService.Object);

        //Act
        var result = await systemUnderTest.Get();

        //Assert
        mockUserService.Verify(
            service => service.GetAllUsers(),
            Times.Once);

    }
    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers());

        var systemUnderTest = new UsersController(mockUserService.Object);

        //Act
        var result = await systemUnderTest.Get();

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task Get_NoUsersFound_Returns404()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var systemUnderTest = new UsersController(mockUserService.Object);

        //Act
        var result = await systemUnderTest.Get();

        //Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

}