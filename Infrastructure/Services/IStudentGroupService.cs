using Domain.Models;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IStudentGroupService
    {
        Task<Response<List<StudentGroup>>> GetAllStudentGroupAsync();
        Task<Response<StudentGroup>> GetStudentGroupByIdAsync(int id);
        Task<Response<string>> AddStudentGroupAsync(StudentGroup studentGroup);
        Task<Response<string>> UpdateStudentGroupAsync(StudentGroup studentGroup);
        Task<Response<bool>> DeleteStudentGroupAsync(int id);
    }
}
