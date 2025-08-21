using Domain.Models.Entities;
using LMS.Presentation.Controllers;
using LMS.Shared.DTOs.ModuleActivityDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace LMS.xUnitTests
{
    public class ModuleActivityControllerTests
    {
        
        Mock<IServiceManager> mockServiceManager = new();
        Mock<IModuleActivityService> mockModuleActivityService = new();
        ModuleActivityController controller;

        public ModuleActivityControllerTests()
        {
            //Setup
            mockServiceManager
               .Setup(sm => sm.ModuleActivityService)
               .Returns(mockModuleActivityService.Object);

            controller = new ModuleActivityController(mockServiceManager.Object);

            // Mock user claims for authorization
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "123"),
                new Claim(ClaimTypes.Name, "testuser"),
                new Claim(ClaimTypes.Role, "User")
            }, "mock"));

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }

        [Fact]
        public async void CreateActivityAsync_ShouldReturnNoContent_WhenActivityIsCreated()
        {
            int mockModuleId = 1;
            CreateModuleActivityDto newActivity = new() {
               Name = "Test Activity",
                Type = "Test Type",
                Description = "Test Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                ModuleId = mockModuleId
            };

            mockModuleActivityService
                .Setup(s => s.CreateActivityAsync(It.IsAny<int>(), It.IsAny<CreateModuleActivityDto>()))
                .Returns(Task.CompletedTask);

            var result = await controller.CreateActivityAsync(mockModuleId, newActivity);

            Assert.IsType<NoContentResult>(result);
            mockModuleActivityService.Verify(
                s => s.CreateActivityAsync(mockModuleId, newActivity),Times.Once);
        }

        [Fact]
        public async Task PatchActivityAsync_ShouldCallService_WhenValidRequest()
        {
            int mockId = 1;
            var patchDoc = new JsonPatchDocument<PatchModuleActivityDto>();
            patchDoc.Replace(a => a.Name, "Updated Name");

            mockModuleActivityService
                .Setup(s => s.PatchModuleActivityAsync(It.IsAny<int>(), It.IsAny<JsonPatchDocument<PatchModuleActivityDto>>()))
                .Returns(Task.CompletedTask);

            await controller.PatchActivityAsync(mockId, patchDoc);

            mockModuleActivityService.Verify(
                s => s.PatchModuleActivityAsync(mockId, patchDoc),
                Times.Once
            );
        }

        [Fact]
        public void GetActivitiesByModule_ShouldReturnActivities_WhenCalled()
        {
            int mockModuleId = 1;
            var expectedActivities = new List<ModuleActivity>
            {
                new ModuleActivity { Id = 1, Name = "Activity 1", ModuleId = mockModuleId },
                new ModuleActivity { Id = 2, Name = "Activity 2", ModuleId = mockModuleId }
            };

            mockModuleActivityService
                .Setup(s => s.GetActivitiesByModule(mockModuleId))
                .Returns(expectedActivities);

            var result = controller.GetActivitiesByModule(mockModuleId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, ((List<ModuleActivity>)result).Count);
            Assert.Equal("Activity 1", ((List<ModuleActivity>)result)[0].Name);
            Assert.Equal("Activity 2", ((List<ModuleActivity>)result)[1].Name);

            mockModuleActivityService.Verify(
                s => s.GetActivitiesByModule(mockModuleId),
                Times.Once
            );
        }
    }
}
