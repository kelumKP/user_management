using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activate.InterviewProject.Core.Models;
using Activate.InterviewProject.Core.Models.Authentication;

namespace Activate.InterviewProject.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(RegisterModel user);

        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetNormalUsers();
        Task<IEnumerable<User>> GetAdminUsers();

        Task<AppUser> GetUserById(Guid userId);

        Task<bool> UpdateUser(AppUser user);

        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(Guid userId);
    }
}
