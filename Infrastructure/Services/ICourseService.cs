using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Services
{
    public interface ICourseService
    {
        Task<Response<List<Course>>> GetAllCourseAsync();
        Task<Response<Course>> GetCourseByIdAsync(int id);
        Task<Response<string>> AddCourseAsync(Course course);
        Task<Response<string>> UpdateCourseAsync(Course course); 
        Task<Response<bool>> DeleteCourseAsync(int id);
    }
}
