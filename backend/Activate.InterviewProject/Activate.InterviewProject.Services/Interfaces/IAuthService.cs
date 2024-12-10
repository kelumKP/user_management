using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activate.InterviewProject.Core.Models;
using Activate.InterviewProject.Core.Models.Authentication;

namespace Activate.InterviewProject.Services.Interfaces
{
    public interface IAuthService 
    {
        Task<AppUser?> Authenticate(LoginModel user);
        //Task<bool> Logout(string userId);
        //Task<bool> LogoutAll();
    }
}
