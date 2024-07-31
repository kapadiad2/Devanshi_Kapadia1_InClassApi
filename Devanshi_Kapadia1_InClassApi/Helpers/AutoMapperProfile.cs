using AutoMapper;
using Devanshi_Kapadia1_InClassApi.Dtos;
using Devanshi_Kapadia1_InClassApi.Models;

namespace Devanshi_Kapadia1_InClassApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
        }
    }
}
