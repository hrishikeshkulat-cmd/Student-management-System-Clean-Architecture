using Restful_Api1.Dto;
using Restful_Api1.Models;

namespace Restful_Api1.Service
{
    public interface IEnrollmentService
    {

        Task<bool> EnrollmentAsync(EnrollmentDto dto);

       Task<bool> EnrollmentExistsAsync(EnrollStudentDto dto);



    }
}
