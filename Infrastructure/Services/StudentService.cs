using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly DapperContext _context;
        public StudentService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddStudentAsync(Student student)
        {
            try
            {
                var sql = $"insert into students(firstName,lastName,email,phone,city)" +
                    $"values('{student.FirstName}','{student.LastName}','{student.Email}','{student.Phone}','{student.City}')";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("Student created");
                }
                return new Response<string>(HttpStatusCode.BadRequest, ("Error in creating"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteStudentAsync(int id)
        {
            try
            {
                var sql = $"Delete from students where id={@id}";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<bool>(true);
                }
                return new Response<bool>(HttpStatusCode.BadRequest, ("Student not found"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<Student>>> GetAllStudentAsync()
        {
            try
            {
                var sql = $"Select * from students";
                var result = await _context.Connection().QueryAsync<Student>(sql);
                return new Response<List<Student>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Student>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Student>> GetStudentByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from students where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Student>(result);
                }
                return new Response<Student>(HttpStatusCode.BadRequest, "Student not found");

            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Student>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateStudentAsync(Student student)
        {
            try
            {
                var sql = $"update students set firstName='{student.FirstName}',lastName='{student.LastName}',email='{student.Email}'," +
                    $"phone='{student.Phone}',city='{student.City}' where id={student.Id}";

                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("Student updated");
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
