using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly DapperContext _context;
        public CourseService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddCourseAsync(Course course)
        {
            try
            {
                var sql = $"insert into courses(courseName,courseDescription,duration,startdate,enddate,studentLimit)" +
                    $"values('{course.CourseName}','{course.CourseDescription}',{course.Duration},'{course.StartDate}'," +
                    $"'{course.EndDate}',{course.StudentLimit})";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result>0)
                {
                    return new Response<string>("Course created");
                }
                return new Response<string>(HttpStatusCode.BadRequest, ("Error in creating course"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteCourseAsync(int id)
        {
            try
            {
                var sql = $"Delete from courses where id={@id}"; 
                var result= await _context.Connection().ExecuteAsync(sql);
                if (result>0)
                {
                    return new Response<bool>(true);
                }
                return new Response<bool>(HttpStatusCode.BadRequest, ("Course not found"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message); 
                return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
            }
        }

        public async Task<Response<List<Course>>> GetAllCourseAsync()
        {
            try
            {
                var sql = $"Select * from courses"; 
                var result= await _context.Connection().QueryAsync<Course>(sql);
                return new Response<List<Course>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Course>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Course>> GetCourseByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from courses where id={@id}"; 
                var result=await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result!=null)
                {
                    return new Response<Course>(result);
                }
                return new Response<Course>(HttpStatusCode.BadRequest, "Course not found");
                
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Course>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateCourseAsync(Course course)
        {
            try
            {
                var sql = $"update courses set courseName='{course.CourseName}',courseDescription='{course.CourseDescription}'," +
                    $"duration={course.Duration} ,startdate='{course.StartDate}',enddate='{course.EndDate}',studentLimit={course.StudentLimit}"+
                    $"where id={course.Id}";

                var result = await _context.Connection().ExecuteAsync(sql);
                if (result>0)
                {
                    return new Response<string>("Course Deleted");
                }
                return new Response<string>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
