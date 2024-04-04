using Domain.Models;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IMentorService
    {
        Task<Response<List<Mentor>>> GetAllMentorAsync();
        Task<Response<Mentor>> GetMentorByIdAsync(int id);
        Task<Response<string>> AddMentorAsync(Mentor mentor);
        Task<Response<string>> UpdateMentorAsync(Mentor mentor);
        Task<Response<bool>> DeleteMentorAsync(int id);
    }
}
