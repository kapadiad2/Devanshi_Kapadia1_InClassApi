using AutoMapper;
using Devanshi_Kapadia1_InClassApi.Controllers;
using Devanshi_Kapadia1_InClassApi.Dtos;
using Devanshi_Kapadia1_InClassApi.Helpers;
using Devanshi_Kapadia1_InClassApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Devanshi_Kapadia1Test
{
    public class CourseControllerTestUnit
    {
        private readonly Mock<ICourseService> _mockService; // Updated to interface
        private readonly CourseController _controller;

        public CourseControllerTestUnit()
        {
            _mockService = new Mock<ICourseService>(); // Use the interface
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            _controller = new CourseController(_mockService.Object);
        }

        [Fact]
        public async Task GetCourseByName_ReturnsCourse()
        {
            var courseName = "Math";
            var courseDto = new CourseDto { Name = courseName };
            _mockService.Setup(service => service.GetCourseByName(courseName)).ReturnsAsync(courseDto);

            var result = await _controller.GetCourseByName(courseName);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<CourseDto>(okResult.Value);
            Assert.Equal(courseName, returnValue.Name);
        }

        [Fact]
        public async Task GetAllCourses_ReturnsAllCourses()
        {
            var courses = new List<CourseDto> { new CourseDto { Name = "Math" }, new CourseDto { Name = "Science" } };
            _mockService.Setup(service => service.GetAllCourses()).ReturnsAsync(courses);

            var result = await _controller.GetAllCourses();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<CourseDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task UpdateCourse_UpdatesCourse()
        {
            var courseDto = new CourseDto { Id = 1, Name = "Math" };
            _mockService.Setup(service => service.UpdateCourse(courseDto)).Returns(Task.CompletedTask);

            var result = await _controller.UpdateCourse(courseDto);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
