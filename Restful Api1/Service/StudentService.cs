using Restful_Api1.Models;


namespace Restful_Api1.Service
{
    public class StudentService : IStudentService
    {
        public List<Student> GETALL()
        {
            return FakeDb.Std;

        }

        public Student getbyid(int id)
        {
            return
                  FakeDb.Std.Find(X => X.Id == id);
        }
        public Student Add(Student student)
        {
            FakeDb.Std.Add(student);
            return student;
        }


        public Student Added(Student student)
        {
            FakeDb.Std.Add(student);
            return student;
        }


        public bool updatestd(int id, StudentDto dto)
        {
            var kk = FakeDb.Std.Find(x => x.Id == id);

            if (kk == null)
            {
                return false;
            }

            kk.Name = dto.Name;
            kk.Age = dto.Age;
            return true;
        }

        public bool delete(int id)
        {
            var hk = FakeDb.Std.Find(x => x.Id == id);
            if (hk == null)
            {
                return false;
            }
            FakeDb.Std.Remove(hk);
            return true;
        }
    }
}
