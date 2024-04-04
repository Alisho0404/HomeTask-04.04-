using Domain.Models;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/MentorGroup/")]
    public class MentorGroupController(IMentorGroupService mentorGroupService):ControllerBase
    { 
        private readonly IMentorGroupService _mentorGroupService=mentorGroupService;

        [HttpGet]
        public async Task<Response<List<MentorGroup>>> GetMentorGroupAsync()
        {
            return await _mentorGroupService.GetAllMentorGroupAsync();
        }

        [HttpGet("{mentorGroupId:int}")]
        public async Task<Response<MentorGroup>> GetMentorGroupByIdAsync(int mentorGroupId)
        {
            return await _mentorGroupService.GeMentorGrouprByIdAsync(mentorGroupId);
        }

        [HttpPost]
        public async Task<Response<string>> CreateMentorGroupAsync(MentorGroup mentorGroup)
        {
            return await _mentorGroupService.AddMentorGroupAsync(mentorGroup);
        }
        [HttpPut]
        public async Task<Response<string>> UpdateMentorGroupAsync(MentorGroup mentorGroup)
        {
            return await _mentorGroupService.UpdateMentorGroupAsync(mentorGroup);
        }
        [HttpDelete("{mentorGroupId:int}")]
        public async Task<Response<bool>> DeleteMentorGroupAsync(int mentorGroupId)
        {
            return await _mentorGroupService.DeleteMentorGroupAsync(mentorGroupId);
        }
    }
}
