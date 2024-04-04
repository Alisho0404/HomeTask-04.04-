using Domain.Models;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/MentorGroup/")]
    public class StudentGroupController(IStudentGroupService studentGroupService):ControllerBase
    { 
        private readonly IStudentGroupService _studentGroupService=studentGroupService;

        [HttpGet]
        public async Task<Response<List<StudentGroup>>> GetStudentGroupAsync()
        {
            return await _studentGroupService.GetAllStudentGroupAsync();
        }

        [HttpGet("{studentGroupId:int}")]
        public async Task<Response<StudentGroup>> GetStudentGroupByIdAsync(int studentGroupId)
        {
            return await _studentGroupService.GetStudentGroupByIdAsync(studentGroupId);
        }

        [HttpPost]
        public async Task<Response<string>> CreateStudentGroupAsync(StudentGroup studentGroup)
        {
            return await _studentGroupService.AddStudentGroupAsync(studentGroup);
        }
        [HttpPut]
        public async Task<Response<string>> UpdateStudentGroupAsync(StudentGroup studentGroup)
        {
            return await _studentGroupService.UpdateStudentGroupAsync(studentGroup);
        }
        [HttpDelete("{studentGroupId:int}")]
        public async Task<Response<bool>> DeleteStudentGroupAsync(int studentGroupId)
        {
            return await _studentGroupService.DeleteStudentGroupAsync(studentGroupId);
        }
    }
}
