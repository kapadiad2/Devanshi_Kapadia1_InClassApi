using AutoMapper;
using Devanshi_Kapadia1_InClassApi.Data;
using Devanshi_Kapadia1_InClassApi.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devanshi_Kapadia1_InClassApi.Services
{
    public class CourseService : ICourseService
    {
        private readonly List<CourseDto> _courses;

        public CourseService()
        {
            _courses = new List<CourseDto>
            {
                new CourseDto
                {
                    Id = 1,
                    Name = "Course1",
                    Description = "Description1",
                    StartDate = new DateTime(2024, 7, 30),
                    EndDate = new DateTime(2024, 10, 30)
                },
                new CourseDto
                {
                    Id = 2,
                    Name = "Course2",
                    Description = "Description2",
                    StartDate = new DateTime(2024, 7, 30),
                    EndDate = new DateTime(2025, 1, 30)
                },
                new CourseDto
                {
                    Id = 3,
                    Name = "Course3",
                    Description = "Description3",
                    StartDate = new DateTime(2024, 7, 30),
                    EndDate = new DateTime(2025, 1, 30)
                }
            };
        }

        public async Task<CourseDto> GetCourseByName(string courseName)
        {
            return await Task.FromResult(_courses.FirstOrDefault(c => c.Name == courseName));
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            return await Task.FromResult(_courses);
        }

        public async Task UpdateCourse(CourseDto courseDto)
        {
            var existingData = _courses.FirstOrDefault(c => c.Id == courseDto.Id);
            if (existingData == null)
            {
                // Handle the case where the course does not exist
                throw new KeyNotFoundException("Course not found.");
            }

            existingData.Name = courseDto.Name;
            existingData.Description = courseDto.Description;
            existingData.StartDate = courseDto.StartDate;
            existingData.EndDate = courseDto.EndDate;

            await Task.CompletedTask; // To align with async signature
        }
    }
}
