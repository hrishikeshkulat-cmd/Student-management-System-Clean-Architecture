using AutoMapper;
using Azure.Messaging;
using Microsoft.AspNetCore.Identity;
using Restful_Api1.Dto;
using Restful_Api1.Models;
using Restful_Api1.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Restful_Api1.Service
{
    public class CouseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CouseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseDto> CreateAsync(CreateCourseDto dto)
        {
            var course = _mapper.Map<Course>(dto);

            var create = await _courseRepository.CreateAsync(course);

            return _mapper.Map<CourseDto>(create);

        }

      public async   Task<CourseDto?> GetByIdAsync(int id)
        {

            var hk = await _courseRepository.GetByIdAsync(id);

            if (hk == null)
            {
                return null;
            }

            return _mapper.Map<CourseDto>(hk);

        }
        public async Task<List<CourseDto>> GetAllAsync()
        {
            var getall = await _courseRepository.GetAllAsync();
            return getall
                .Select(c => _mapper.Map<CourseDto>(c))
                .ToList();
        }

       public async  Task<bool> UpdateAsync(int id, UpdateCourseDto course)
        {
            var update = await _courseRepository.GetByIdAsync(id);

            if (update == null)
                 return false;
           
            _mapper.Map(course, update);

            await _courseRepository.UpdateAsync(update);
            return true;
        }




        public async Task<bool> DeleteAsync(int id)
        {
            var delete =await _courseRepository.GetByIdAsync(id);
            if(delete==null)
                return false;
            await _courseRepository.DeleteAsync(delete);
            return true;





        }



    }
}

