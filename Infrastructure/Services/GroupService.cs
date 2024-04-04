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
    public class GroupService : IGroupService
    {
        private readonly DapperContext _context;
        public GroupService()
        {
            _context = new DapperContext();
        }
        public async Task<Response<string>> AddGroupAsync(Group group)
        {
            try
            {
                var sql = $"insert into groups(groupName,groupDescription,courseId)" +
                    $"values('{group.GroupName}','{group.GroupDescription}',{group.CourseId})";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("Group created");
                }
                return new Response<string>(HttpStatusCode.BadRequest, ("Error in creating"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteGroupAsync(int id)
        {
            try
            {
                var sql = $"Delete from groups where id={@id}";
                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<bool>(true);
                }
                return new Response<bool>(HttpStatusCode.BadRequest, ("Group not found"));
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<Group>>> GetAllGroupAsync()
        {
            try
            {
                var sql = $"Select * from groups";
                var result = await _context.Connection().QueryAsync<Group>(sql);
                return new Response<List<Group>>(result.ToList());
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<List<Group>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<Group>> GetGroupByIdAsync(int id)
        {
            try
            {
                var sql = $"Select * from groups where id={@id}";
                var result = await _context.Connection().QueryFirstOrDefaultAsync(sql);
                if (result != null)
                {
                    return new Response<Group>(result);
                }
                return new Response<Group>(HttpStatusCode.BadRequest, "Group not found");

            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return new Response<Group>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateGroupAsync(Group group)
        {
            try
            {
                var sql = $"update groups set groupName='{group.GroupName}',groupDescription='{group.GroupDescription}'," +
                    $"courseId={group.CourseId} where id={group.Id}";

                var result = await _context.Connection().ExecuteAsync(sql);
                if (result > 0)
                {
                    return new Response<string>("groups Deleted");
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
