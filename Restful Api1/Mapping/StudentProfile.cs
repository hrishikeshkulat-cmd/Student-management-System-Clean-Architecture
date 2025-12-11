using AutoMapper;
using Restful_Api1.Dto;
using Restful_Api1.Models;

namespace Restful_Api1.Mapping
{
    public class StudentProfile : Profile
    {

        public StudentProfile()

        {
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<Student, StudentWithDepartmentDto>()
                .ForMember(dest => dest.DepartmentName
                , opt => opt.MapFrom(src => src.Department.DepartmentName));

            CreateMap<Department, DepartmentDto>();

            CreateMap<Course, CourseDto>();
            CreateMap<CreateCourseDto, Course>();
            CreateMap<UpdateCourseDto, Course>();

            CreateMap<Enrollment, EnrollmentDto>();
        }


    }
}
