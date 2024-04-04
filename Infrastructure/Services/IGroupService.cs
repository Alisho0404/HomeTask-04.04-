using Domain.Models;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IGroupService
    {
        Task<Response<List<Group>>> GetAllGroupAsync();
        Task<Response<Group>> GetGroupByIdAsync(int id);
        Task<Response<string>> AddGroupAsync(Group group);
        Task<Response<string>> UpdateGroupAsync(Group group);
        Task<Response<bool>> DeleteGroupAsync(int id);
    }
}
