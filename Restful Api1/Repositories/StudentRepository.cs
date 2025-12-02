using Microsoft.EntityFrameworkCore;
using Restful_Api1.Models;
using Restful_Api1.Service;
using System.Threading.Tasks;


namespace Restful_Api1.Repositories
{
    public class StudentRepository: IStudentRepository
    {
        private readonly AppDbContext _Context;

        public StudentRepository(AppDbContext appDbContext)
        {
            _Context = appDbContext;
        }

        //get all student list
        public async Task<List<Student>> GetAllAsync()
        {
            return await _Context.Students.ToListAsync();
        }
        //get student by id
        public async Task< Student> GetByIdAsync(int id)
        {
            var hk= await  _Context.Students.FirstOrDefaultAsync(x => x.Id==id);
           return   hk;
        }

        //add student 
         public async Task < Student>  AddAsync(Student student)
        {
             await _Context.Students.AddAsync(student);
            await _Context.SaveChangesAsync();
             return  student;
        }
        //update student 
       public async Task< bool> UpdateAsync(int id, StudentDto dto)
        {
            var mk =  await GetByIdAsync( id);
            if(mk != null)
            {
                return false;
            }

            mk.Name=dto.Name;
            mk.Age=dto.Age;
           await _Context.SaveChangesAsync();
            return  true;
        }
       public  async Task<bool> DeleteAsync(int id)
        {
            var hk =  await GetByIdAsync(id);
            if (hk != null)
            {
                return false;
            }
            await _Context.SaveChangesAsync();
            return true;

        }



    }
}
