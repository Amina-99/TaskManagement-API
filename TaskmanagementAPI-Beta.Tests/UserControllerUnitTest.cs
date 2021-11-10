using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Controllers;
using TaskmanagementAPI_Beta.Models.Dtos;
using TaskmanagementAPI_Beta.Services.Interfaces;
using Xunit;

namespace TaskmanagementAPI_Beta.Tests
{
    public class UserControllerUnitTest
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<HttpRequest> _mockRequest;
        private UserController _controller;

        public UserControllerUnitTest()
        {
            _mockUserService = new Mock<IUserService>();
            _mockRequest = new Mock<HttpRequest>();
        }

        [Fact]
        public async Task GetAllUsers_Returns_Ok()
        {
            // Arrange 
            _mockUserService.Setup(t => t.GetAllUsers())
                .ReturnsAsync(() => new List<UserReadDto>() { new UserReadDto() });
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/User"));

            _controller = new UserController(_mockUserService.Object);

            // Act
            var response = (OkObjectResult)await _controller.GetAllUsers();
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.OK, actual);
        }

        [Fact]
        public async Task GetAllUsers_Returns_BadRequest()
        {
            // Arrange 
            _mockUserService.Setup(t => t.GetAllUsers())
                .ReturnsAsync(() => throw new Exception());
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/User"));

            _controller = new UserController(_mockUserService.Object);

            // Act
            var response = (BadRequestObjectResult)await _controller.GetAllUsers();
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }

        [Fact]
        public async Task GetUserById_Returns_Ok()
        {
            // Arrange 
            _mockUserService.Setup(t => t.GetUserByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => new UserReadDto { } )  ;
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/User/{id}"));

            _controller = new UserController(_mockUserService.Object);

            // Act
            var response = (OkObjectResult)await _controller.GetUserByIdAsync(It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.OK, actual);
        }

        [Fact]
        public async Task GetUserById_Returns_BadRequest()
        {
            // Arrange 
            _mockUserService.Setup(t => t.GetUserByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception());
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/User/{id}"));

            _controller = new UserController(_mockUserService.Object);

            // Act
            var response = (BadRequestObjectResult)await _controller.GetUserByIdAsync(It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }

        [Fact]
        public async Task UpdateUserAsyncId_Returns_NoContent()
        {
            // Arrange 
            _mockUserService.Setup(t => t.UpdateUserByIdAsync(It.IsAny<int>(), It.IsAny<UserCreateDto>()))
                .ReturnsAsync(() => true);
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/User/{id}"));

            _controller = new UserController(_mockUserService.Object);

            // Act
            var response = (NoContentResult)await _controller.UpdateUserAsync(It.IsAny<int>(), It.IsAny<UserCreateDto>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, actual);
        }

        [Fact]
        public async Task UpdateUserAsyncId_Returns_NotFound()
        {
            // Arrange 
            _mockUserService.Setup(t => t.UpdateUserByIdAsync(It.IsAny<int>(), It.IsAny<UserCreateDto>()))
                .ReturnsAsync(() => false);
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/User/{id}"));

            _controller = new UserController(_mockUserService.Object);

            // Act
            var response = (NotFoundResult)await _controller.UpdateUserAsync(It.IsAny<int>(), It.IsAny<UserCreateDto>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, actual);
        }

        [Fact]
        public async Task UpdateUserAsyncId_Returns_BadRequest()
        {
            // Arrange 
            _mockUserService.Setup(t => t.UpdateUserByIdAsync(It.IsAny<int>(), It.IsAny<UserCreateDto>()))
                .ReturnsAsync(() => throw new Exception());
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/User/{id}"));

            _controller = new UserController(_mockUserService.Object);

            // Act
            var response = (BadRequestObjectResult)await _controller.UpdateUserAsync(It.IsAny<int>(), It.IsAny<UserCreateDto>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }

        [Fact]
        public async Task DeleteUserById_Returns_NoContent()
        {
            // Arrange 
            _mockUserService.Setup(t => t.DeleteUserAsync(It.IsAny<int>()))
                .ReturnsAsync(() => true);
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/User/{id}"));

            _controller = new UserController(_mockUserService.Object);

            // Act
            var response = (NoContentResult)await _controller.DeleteUserAsync(It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, actual);
        }

        [Fact]
        public async Task DeleteUserById_Returns_BadRequestDeleting()
        {
            // Arrange 
            _mockUserService.Setup(t => t.DeleteUserAsync(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("Deleting task failed"));
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/User/{id}"));

            _controller = new UserController(_mockUserService.Object);

            // Act
            var response = (BadRequestObjectResult)await _controller.DeleteUserAsync(It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }

        [Fact]
        public async Task DeleteUserById_Returns_BadRequestException()
        {
            // Arrange 
            _mockUserService.Setup(t => t.DeleteUserAsync(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception());
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/User/{id}"));

            _controller = new UserController(_mockUserService.Object);

            // Act
            var response = (BadRequestObjectResult)await _controller.DeleteUserAsync(It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }

        [Fact]
        public async Task CreateUser_Returns_Status201()
        {
            // Arrange 
            _mockUserService.Setup(t => t.CreateUserAsync(It.IsAny<UserCreateDto>()))
                .ReturnsAsync(() => true);
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/User"));

            _controller = new UserController(_mockUserService.Object);

            // Act
            var response = (StatusCodeResult)await _controller.CreateUserAsync(It.IsAny<UserCreateDto>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.Created, actual);
        }

    }
}
