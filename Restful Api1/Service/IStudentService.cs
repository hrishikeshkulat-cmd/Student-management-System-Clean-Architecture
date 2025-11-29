using Restful_Api1.Models;

namespace Restful_Api1.Service
{
    public interface IStudentService
    {

        List<Student> GETALL();

        Student getbyid(int id);

        Student Add(Student student);

        bool updatestd(int id, StudentDto dto);

        bool delete(int id);


    }
}
