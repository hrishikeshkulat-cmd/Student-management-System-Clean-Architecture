using AutoMapper;
using Restful_Api1.Dto;
using Restful_Api1.Models;
using Restful_Api1.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;




   
namespace Restful_Api1.Service
{
    public class EnrollmentService: IEnrollmentService
    {

        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;


        public EnrollmentService(IEnrollmentRepository enrollmentRepository,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }


        public async Task<bool> EnrollmentExistsAsync(EnrollStudentDto dto)
        {
            // Validate student exists
            var exist = await _studentRepository!.GetByIdAsync(dto.StudentId);
            if (exist == null) return false;

            // Validate course exists
            var Courseexist = await _courseRepository.GetByIdAsync(dto.CourseId);
            if (Courseexist == null) return false;

            //Prevent duplicate enrollment
            var enrollmentExist = await _enrollmentRepository.EnrollmentExistsAsync(dto.StudentId, dto.CourseId);

            var Enrollment = new Enrollment
            {

                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                EnrolledOn = DateTime.UtcNow,
                Grade = null
            };

            await _enrollmentRepository.AddEnrollmentAsync(Enrollment);
            return true;

        }
       public async  Task<bool> UnenrollStudentAsync(int studentId, int courseId)
        {

           await   _enrollmentRepository.RemoveEnrollmentAsync(studentId, courseId);
            return true;

        }
       public async  Task<List<CourseDto>> GetCoursesForStudentAsync(int studentId)
        {
            var courses = await  _enrollmentRepository.GetCoursesForStudentAsync(studentId);
            return courses
                .Select(s => _mapper.Map<CourseDto>(s)).ToList();
        }


      public async   Task<List<StudentDto>> GetStudentsForCourseAsync(int courseId)
        {
            var student = await _enrollmentRepository.GetStudentsForCourseAsync(courseId);
            return student
                .Select(s =>_mapper.Map<StudentDto>(s)).ToList();
        }



    }
}
