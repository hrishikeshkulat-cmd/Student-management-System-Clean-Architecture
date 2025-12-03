using Restful_Api1.Models;
using Restful_Api1.Repositories;
using System.Threading.Tasks;


namespace Restful_Api1.Service
{

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }



        public async Task < List<Student>> GetAllAsync()
        {
            return await  _repo.GetAllAsync();

        }

        public async Task<Student> GetByIdAsync(int id)
        {
           return await  _repo.GetByIdAsync( id);
        }
        public async Task<Student> AddAsync(Student student)
        {
           return await _repo.AddAsync(student);
        }


     
        public async Task< bool> UpdateAsync(int id, StudentDto dto)
        {
          return await _repo.UpdateAsync( id, dto);
        }

        public async Task< bool> DeleteAsync(int id)
        {
           return await _repo.DeleteAsync( id);
        }


        public async Task<List<Student>> FilterAsync(int? minAge, int? maxAge)
        {

           return await _repo.FilterAsync( minAge, maxAge);


        }
       public  Task<List<Student>> AdvancedFilterAsync(string? name, int? minAge, int? maxAge)
        {

            return _repo.AdvancedFilterAsync( name, minAge, maxAge);

        }
        public Task<List<Student>> SortAsync(string orderBy, string direction)
        {

            return _repo.SortAsync( orderBy, direction);
        }

       public async Task<List<Student>> SearchAsync(string? search)
        {
            return await _repo.SearchAsync(search);
        }


    }

}
