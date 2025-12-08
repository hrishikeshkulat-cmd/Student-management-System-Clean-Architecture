using AutoMapper;
using Restful_Api1.Dto;
using Restful_Api1.Models;
using Restful_Api1.Repositories;
using Restful_Api1.Mapping;



namespace Restful_Api1.Service
{

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly IDepartmentService _deptService;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repo, IDepartmentService deptService, IMapper mapper)
        {
            _repo = repo;
            _deptService = deptService;
            _mapper = mapper;
        }


        public async Task<List<Student>> GetAllAsync()
        {
            return await _repo.GetAllAsync();

        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }




        public async Task<Student?> CreateStudentAsync(CreateStudentDto dto)
        {
            var dept = await _deptService.GetDepartmentByIdAsync(dto.DepartmentId);
            if (dept == null) return null;

            var student = new Student
            {
                Name = dto.Name,
                Age = dto.Age,
                DepartmentId = dto.DepartmentId
            };

            return await _repo.CreateStudentAsync(student);
        }

        public async Task<bool> UpdateStudentAsync(int id, UpdateStudentDto dto)
        {
            //check if the student is valid
            var hk = await _repo.GetByIdAsync(id);
            if (hk == null) return false;
            //check if the department is valid.
            var valid = await _deptService.GetDepartmentByIdAsync(dto.DepartmentId);
            if (valid == null) return false;


            return await _repo.UpdateStudentAsync(id, dto);


        }
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var hk = await _repo.DeleteStudentAsync(id);
            return hk;
        }


        public async Task<StudentWithDepartmentDto?> GetByIdWithDepartmentAsync(int id)
        {

            var hk= await _repo.GetByIdWithDepartmentAsync(id);
            if (hk == null) return null;

            return  _mapper.Map<StudentWithDepartmentDto>(hk);



        }

       public async Task<List<object>> GetAllStudentsWithQueryAsync(StudentQueryParameters parameters)
        {
            var hk = await _repo.GetAllWithQueryAsync(parameters);

            if (!parameters.IncludeDepartment)
            {
                return hk
                    .Select(s => _mapper.Map<StudentDto>(s))
                    .Cast<object>()
                    .ToList();
            }


                return hk
                    .Select(s => _mapper.Map<StudentWithDepartmentDto>(s))
                .Cast<object>()
                .ToList();
            
             
        }





    }

}
