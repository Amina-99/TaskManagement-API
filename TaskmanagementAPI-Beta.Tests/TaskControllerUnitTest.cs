using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Controllers;
using TaskmanagementAPI_Beta.Domain;
using TaskmanagementAPI_Beta.Models.Dtos;
using Xunit;

namespace TaskmanagementAPI_Beta.Tests
{
    public class TaskControllerUnitTest
    {
        private readonly Mock<ITaskService> _mockTaskService;
        private readonly Mock<HttpRequest> _mockRequest;
        private TasksController _controller;

        public TaskControllerUnitTest()
        {
            _mockTaskService = new Mock<ITaskService>();
            _mockRequest = new Mock<HttpRequest>();            
        }

        [Fact]
        public async Task GetAllTasks_Returns_Ok()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.GetAllTasks())
                .ReturnsAsync(() => new List<TaskReadDto>() { new TaskReadDto() });
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (OkObjectResult)await _controller.GetAllTasks();
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.OK, actual);
        }

        [Fact]
        public async Task GetAllTasks_Returns_BadRequest()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.GetAllTasks())
                .ReturnsAsync(() => throw new Exception());
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (BadRequestObjectResult)await _controller.GetAllTasks();
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }

        [Fact]
        public async Task ChangeTaskStatus_Returns_Ok()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.ChangeStatus(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(() =>  true );
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (OkResult)await _controller.ChangeStatus(It.IsAny<int>(), It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.OK, actual);
        }

        [Fact]
        public async Task ChangeTaskStatus_Returns_BadRequest()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.ChangeStatus(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(() => false);
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (BadRequestObjectResult)await _controller.ChangeStatus(It.IsAny<int>(), It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }

        [Fact]
        public async Task GetTaskByIdAsync_Returns_Ok()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.GetTaskByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => new TaskReadDto());
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks/{id}"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (OkObjectResult)await _controller.GetTaskByIdAsync(It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.OK, actual);
        }

        [Fact]
        public async Task GetTaskByIdAsync_Returns_BadRequest()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.GetTaskByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception());
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks/{id}"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (BadRequestObjectResult)await _controller.GetTaskByIdAsync(It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }

        [Fact]
        public async Task GetTaskByIdAsync_Returns_NotFound()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.GetTaskByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks/{id}"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (NotFoundResult)await _controller.GetTaskByIdAsync(It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, actual);
        }

        [Fact]
        public async Task UpdateTask_Returns_NoContent()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.UpdateTaskByIdAsync(It.IsAny<int>(), It.IsAny<TaskCreateDto>()))
                .ReturnsAsync(() => true);
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks/{id}"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (NoContentResult)await _controller.UpdateTaskAsync(It.IsAny<int>(), It.IsAny<TaskCreateDto>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, actual);
        }

        [Fact]
        public async Task UpdateTask_Returns_BadRequest()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.UpdateTaskByIdAsync(It.IsAny<int>(), It.IsAny<TaskCreateDto>()))
                .ReturnsAsync(() => throw new Exception());
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks/{id}"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (BadRequestObjectResult)await _controller.UpdateTaskAsync(It.IsAny<int>(), It.IsAny<TaskCreateDto>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }

        [Fact]
        public async Task UpdateTaskByIdAsync_Returns_NotFound()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.UpdateTaskByIdAsync(It.IsAny<int>(), It.IsAny<TaskCreateDto>()))
                .ReturnsAsync(() => false);
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks/{id}"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (NotFoundResult)await _controller.UpdateTaskAsync(It.IsAny<int>(), It.IsAny<TaskCreateDto>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, actual);
        }

        [Fact]
        public async Task DeleteTaskAsync_Returns_NoContent()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.DeleteTaskAsync(It.IsAny<int>()))
                .ReturnsAsync(() => true);
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks/{id}"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (NoContentResult)await _controller.DeleteTaskAsync(It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, actual);
        }

        [Fact]
        public async Task DeleteTaskAsync_Returns_BadRequest()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.DeleteTaskAsync(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception());
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks/{id}"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (BadRequestObjectResult)await _controller.DeleteTaskAsync(It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }

        [Fact]
        public async Task DeleteTaskAsync_Returns_BadRequestBoolean()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.DeleteTaskAsync(It.IsAny<int>()))
                .ReturnsAsync(() => false);
            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks/{id}"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (BadRequestObjectResult)await _controller.DeleteTaskAsync(It.IsAny<int>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, actual);
        }

        [Fact]
        public async Task CreateTask_Returns_Status201()
        {
            // Arrange 
            _mockTaskService.Setup(t => t.CreateTaskAsync(It.IsAny<TaskCreateDto>()));

            _mockRequest.Setup(m => m.Scheme)
                .Returns("https");
            _mockRequest.Setup(m => m.Host)
                .Returns(new HostString("tasks.com"));
            _mockRequest.Setup(m => m.Path)
                .Returns(new PathString("/api/Tasks"));

            _controller = new TasksController(_mockTaskService.Object);

            // Act
            var response = (StatusCodeResult)await _controller.CreateTaskAsync(It.IsAny<TaskCreateDto>());
            var actual = (HttpStatusCode)response.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.Created, actual);
        }
    }
}
