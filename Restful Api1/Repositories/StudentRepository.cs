using Microsoft.EntityFrameworkCore;
using Restful_Api1.Dto;
using Restful_Api1.Models;


namespace Restful_Api1.Repositories
{
    public class StudentRepository : IStudentRepository
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
        public async Task<Student> GetByIdAsync(int id)
        {
            var hk = await _Context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return hk;
        }



        public async Task<Student?> CreateStudentAsync(Student student)
        {

            var Create = _Context.Students.Add(student).Entity;
            await _Context.SaveChangesAsync();
            return Create;

        }
        public async Task<bool> UpdateStudentAsync(int id, UpdateStudentDto dto)
        {
            var hk = await _Context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (hk == null) return false;

            hk.Name = dto.Name;
            hk.Age = dto.Age;
            hk.DepartmentId = dto.DepartmentId;


            await _Context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var hk = await _Context.Students.FirstOrDefaultAsync(h => h.Id == id);

            _Context.Students.Remove(hk);
            await _Context.SaveChangesAsync();
            return true;


        }

        public async Task<Student?> GetByIdWithDepartmentAsync(int id)
        {
            return await _Context.Students
                .Include(s => s.Department)
                .FirstOrDefaultAsync(s => s.Id == id);

        }

        public async Task<List<Student>> GetAllWithQueryAsync(StudentQueryParameters parameters)
        {

            //start query
            IQueryable<Student> query = _Context.Students.AsNoTracking();

            //include department
            if (parameters.IncludeDepartment)
            {
                query = query.Include(s => s.Department);
            }

            //sorting
            if (!string.IsNullOrWhiteSpace(parameters.Sortby))
            {

                switch (parameters.Sortby.ToLower())

                {
                    case "name":

                        query = query.OrderBy(s => s.Name);
                        break;

                    case "age":

                        query = query.OrderBy(s => s.Age);
                        break;
                }
            }
                //start pagitation

                int skip = (parameters.Page - 1) * parameters.Pagesize;

                return await query
                    .Skip(skip)
                    .Take(parameters.Pagesize)
                    .ToListAsync();

            




        }







    }








}
