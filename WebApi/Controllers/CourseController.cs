using Microsoft.AspNetCore.Mvc;
using Domain.Responses;
using Infrastructure.Services;
using Domain.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/Courses/")]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        private readonly ICourseService _courseService = courseService;

        [HttpGet]
        public async Task<Response<List<Course>>> GetCourseAsync()
        {
            return await _courseService.GetAllCourseAsync();
        } 

        [HttpGet("{courseId:int}")] 
        public async Task<Response<Course>> GetCourseByIdAsync(int courseId)
        {
            return await _courseService.GetCourseByIdAsync(courseId);
        }

        [HttpPost] 
        public async Task<Response<string>> CreateCourseAsync(Course course)
        {
            return await _courseService.AddCourseAsync(course);
        }
        [HttpPut] 
        public async Task<Response<string>> UpdateCourseAsync(Course course)
        {
            return await _courseService.UpdateCourseAsync(course);
        }
        [HttpDelete("{courseId:int}")]
        public async Task<Response<bool>> DeleteCourseAsync(int courseId)
        {
            return await _courseService.DeleteCourseAsync(courseId);
        }

    }
}
