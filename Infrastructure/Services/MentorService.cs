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
    public class MentorService : IMentorService
    {
        private readonly DapperContext _context;
        public MentorService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddMentorAsync(Mentor mentor)
        {
            try
            {
                var sql = $"insert into mentors(firstName,lastName,email,phone,city)" +
                    $"values('{mentor.FirstName}','{mentor.LastName}','{mentor.Email}','{mentor.Phone}','{mentor.City}')";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("Mentor created");
                }
                return new Response<string>(HttpStatusCode.BadRequest, ("Error in creating"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteMentorAsync(int id)
        {
            try
            {
                var sql = $"Delete from mentors where id={@id}";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<bool>(true);
                }
                return new Response<bool>(HttpStatusCode.BadRequest, ("Mentor not found"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<Mentor>>> GetAllMentorAsync()
        {
            try
            {
                var sql = $"Select * from mentors";
                var result = await _context.Connection().QueryAsync<Mentor>(sql);
                return new Response<List<Mentor>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Mentor>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Mentor>> GetMentorByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from mentors where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Mentor>(result);
                }
                return new Response<Mentor>(HttpStatusCode.BadRequest, "Mentor not found");

            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Mentor>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateMentorAsync(Mentor mentor)
        {
            try
            {
                var sql = $"update mentors set firstName='{mentor.FirstName}',lastName='{mentor.LastName}',email='{mentor.Email}'," +
                    $"phone='{mentor.Phone}',city='{mentor.City}' " +
                    $"where id={mentor.Id}";

                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("Mentor updated");
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
