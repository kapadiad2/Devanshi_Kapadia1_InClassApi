using Devanshi_Kapadia1_InClassApi.Dtos;

namespace Devanshi_Kapadia1_InClassApi.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCourses();
        Task<CourseDto> GetCourseByName(string courseName);
        Task UpdateCourse(CourseDto courseDto);
    }
}
