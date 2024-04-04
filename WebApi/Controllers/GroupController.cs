using Domain.Models;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/Groups/")]
    public class GroupController(IGroupService groupService):ControllerBase
    { 
        private readonly IGroupService _groupService=groupService;

        [HttpGet]
        public async Task<Response<List<Group>>> GetGroupAsync()
        {
            return await _groupService.GetAllGroupAsync();
        }

        [HttpGet("{groupId:int}")]
        public async Task<Response<Group>> GetGroupByIdAsync(int GroupId)
        {
            return await _groupService.GetGroupByIdAsync(GroupId);
        }

        [HttpPost]
        public async Task<Response<string>> CreateGroupAsync(Group group)
        {
            return await _groupService.AddGroupAsync(group);
        }
        [HttpPut]
        public async Task<Response<string>> UpdateGroupAsync(Group group)
        {
            return await _groupService.UpdateGroupAsync(group);
        }
        [HttpDelete("{groupId:int}")]
        public async Task<Response<bool>> DeleteGroupAsync(int groupId)
        {
            return await _groupService.DeleteGroupAsync(groupId);
        }
    }
}
