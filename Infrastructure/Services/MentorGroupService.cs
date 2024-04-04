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
    public class MentorGroupService : IMentorGroupService
    {
        private readonly DapperContext _context;
        public MentorGroupService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddMentorGroupAsync(MentorGroup mentorGroup)
        {
            try
            {
                var sql = $"insert into mentorGroup(mentorid,groupid)" +
                    $"values({mentorGroup.MentorId},{mentorGroup.GroupId})";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("MentorGroup created");
                }
                return new Response<string>(HttpStatusCode.BadRequest, ("Error in creating"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteMentorGroupAsync(int id)
        {
            try
            {
                var sql = $"Delete from mentorGroup where id={@id}";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<bool>(true);
                }
                return new Response<bool>(HttpStatusCode.BadRequest, ("MentorGroup not found"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<MentorGroup>> GeMentorGrouprByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from mentorGroup where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<MentorGroup>(result);
                }
                return new Response<MentorGroup>(HttpStatusCode.BadRequest, "MentorGroup not found");

            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<MentorGroup>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<MentorGroup>>> GetAllMentorGroupAsync()
        {
            try
            {
                var sql = $"Select * from mentorgroup";
                var result = await _context.Connection().QueryAsync<MentorGroup>(sql);
                return new Response<List<MentorGroup>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<MentorGroup>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateMentorGroupAsync(MentorGroup mentorGroup)
        {
            try
            {
                var sql = $"update mentorGroup set mentorid={mentorGroup.MentorId},groupid={mentorGroup.GroupId} " +
                    $"where id={mentorGroup.Id}";

                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("Mentorgroup updated");
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
