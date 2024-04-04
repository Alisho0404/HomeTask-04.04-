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
    public class StudentGroupService : IStudentGroupService
    {
        private readonly DapperContext _context;
        public StudentGroupService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddStudentGroupAsync(StudentGroup studentGroup)
        {
            try
            {
                var sql = $"insert into studentGroup(studentId,groupId)" +
                    $"values({studentGroup.StudentId},{studentGroup.GroupId})";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("StudentGroup created");
                }
                return new Response<string>(HttpStatusCode.BadRequest, ("Error in creating"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteStudentGroupAsync(int id)
        {
            try
            {
                var sql = $"Delete from studentgroup where id={@id}";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<bool>(true);
                }
                return new Response<bool>(HttpStatusCode.BadRequest, ("StudentGroup not found"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<StudentGroup>>> GetAllStudentGroupAsync()
        {
            try
            {
                var sql = $"Select * from studentGroup";
                var result = await _context.Connection().QueryAsync<StudentGroup>(sql);
                return new Response<List<StudentGroup>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<StudentGroup>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<StudentGroup>> GetStudentGroupByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from studentGroup where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<StudentGroup>(result);
                }
                return new Response<StudentGroup>(HttpStatusCode.BadRequest, "StudentGroup not found");

            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<StudentGroup>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateStudentGroupAsync(StudentGroup studentGroup)
        {
            try
            {
                var sql = $"update studentGroup set studentId={studentGroup.StudentId},groupId={studentGroup.GroupId} " +
                    $"where id={studentGroup.Id}";

                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("Studentgroup updated");
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
