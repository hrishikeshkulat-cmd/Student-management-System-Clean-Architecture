using Restful_Api1.Models;
using Restful_Api1.Repositories;


namespace Restful_Api1.Service
{

 


    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }



        public List<Student> GETALL()
        {
            return _repo.GETALL();

        }

        public Student getbyid(int id)
        {
           return _repo.getbyid(id);
        }
        public Student Add(Student student)
        {
           return _repo.Add(student);
        }


        public Student Added(Student student)
        {
            return _repo.Add(student);
        }


        public bool updatestd(int id, StudentDto dto)
        {
          return _repo.updatestd(id, dto);
        }

        public bool delete(int id)
        {
           return _repo.delete(id);
        }
    }
}
