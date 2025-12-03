using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using Restful_Api1.Models;
using System.Reflection.Metadata.Ecma335;


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
            var mk = await _Context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(mk == null)
            {
                return false;
            }

            mk.Name=dto.Name;
            mk.Age=dto.Age;
           await _Context.SaveChangesAsync();
            return  true;
        }
       public  async Task<bool> DeleteAsync (int id)
        {
          var hk = await _Context.Students.FirstOrDefaultAsync(x => x.Id == id);
          
            if (hk == null)
            {
                return false;
            }
           _Context.Students.Remove(hk);
            await _Context.SaveChangesAsync();
            return true;

        }

        public async Task <List<Student>> FilterAsync(int? minAge, int? maxAge)
        {

            var query= _Context.Students.AsQueryable();

            if(minAge.HasValue )
            
            query = query.Where(x => x.Age >= minAge.Value);

            if(maxAge.HasValue )

            query=query.Where(x => x.Age <= maxAge.Value);


            query=query.OrderBy(x=> x.Id);

            return  await query.ToListAsync();
            
        }

        //MUltisearach by filter
        public  async Task<List<Student>>AdvancedFilterAsync(string? name, int? minAge, int? maxAge)
        {

            var query = _Context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                var lower = name.ToLower();

                query = query.Where(x => x.Name.ToLower().Contains(lower));

            }

            if(minAge.HasValue)
            {
                query.Where(x => x.Age >= minAge.Value);

            }

            if (maxAge.HasValue)
             {
                query.Where(x => x.Age <= maxAge.Value);
            }

            query = query.OrderBy(x => x.Id);

            return await query.ToListAsync();

        }

        public async Task<List<Student>> SortAsync(string orderBy, string direction)
        {
            var query = _Context.Students.AsQueryable();


            orderBy= orderBy?.ToLower();
            direction= direction?.ToLower();


            switch (orderBy)
            {
                case "name":
                    query = direction == "desc"
                        ? query.OrderByDescending(x => x.Name)
                        : query.OrderBy(x => x.Id);
                break;



                case "age":
                    query=direction=="desc"
                        ?query.OrderByDescending(x=>x.Age)
                        : query.OrderBy(x => x.Id);
                break;




                case "id":
                    query = direction == "desc"
                        ? query.OrderByDescending(x => x.Id)
                        : query.OrderBy(x => x.Id);
                    break;
            }
            return await query.ToListAsync();

        }

        public async Task<List<Student>> SearchAsync(string? search)
        {
            var query = _Context.Students.AsQueryable();

            if(!string.IsNullOrEmpty(search))
            {
                var Lower = search.ToLower();

               query= query.Where(x => x.Name !=null && x.Name .ToLower().Contains(Lower));
            }
            query = query.OrderBy(x => x.Id);
            return await query.ToListAsync();
        }





    }
}
