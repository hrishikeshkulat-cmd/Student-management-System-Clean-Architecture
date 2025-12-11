using AutoMapper;
using Restful_Api1.Dto;
using Restful_Api1.Models;
using Restful_Api1.Repositories;



   
namespace Restful_Api1.Service
{
    public class EnrollmentService: IEnrollmentService
    {

        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly IMapper? _mapper;


        public EnrollmentService(IEnrollmentRepository enrollmentRepository,
            StudentRepository studentRepository,
            CourseRepository courseRepository,
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


    }
}
