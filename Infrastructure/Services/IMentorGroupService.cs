using Domain.Models;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IMentorGroupService
    {
        Task<Response<List<MentorGroup>>> GetAllMentorGroupAsync();
        Task<Response<MentorGroup>> GeMentorGrouprByIdAsync(int id);
        Task<Response<string>> AddMentorGroupAsync(MentorGroup mentorGroup);
        Task<Response<string>> UpdateMentorGroupAsync(MentorGroup mentorGroup);
        Task<Response<bool>> DeleteMentorGroupAsync(int id);
    }
}
