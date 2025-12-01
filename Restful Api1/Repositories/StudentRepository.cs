using Restful_Api1.Models;
using Restful_Api1.Service;

namespace Restful_Api1.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        //get all student list
       public  List<Student> GETALL()
        {

            return FakeDb.Std.ToList();

        }
        //get student by id
        public Student getbyid(int id)
        {
           var hk= FakeDb.Std.FirstOrDefault(x => x.Id==id)?? new Student();
            
           return hk;
        }

        //add student 
         public  Student Add(Student student)
        {
             FakeDb.Std.Add(student);
             return student;
        }
        //update student 
       public  bool updatestd(int id, StudentDto dto)
        {
            var mk =getbyid(id);
            if(mk != null)
            {
                return false;
            }

            mk.Name=dto.Name;
            mk.Age=dto.Age;
            return true;
        }
       public  bool delete(int id)
        {
            var hk = getbyid(id);
            if (hk != null)
            {
                return false;
            }
            FakeDb.Std.Remove(hk);
            return true;

        }



    }
}
