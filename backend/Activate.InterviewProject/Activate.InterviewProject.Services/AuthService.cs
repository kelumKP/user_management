using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activate.InterviewProject.Core.Interfaces;
using Activate.InterviewProject.Core.Models;
using Activate.InterviewProject.Core.Models.Authentication;
using Activate.InterviewProject.Services.Auth;
using Activate.InterviewProject.Services.Interfaces;

namespace Activate.InterviewProject.Services
{
    public class AuthService : IAuthService
    {
        public IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AppUser?> Authenticate(LoginModel user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var dbUser = _unitOfWork.Users.GetAll().Result.FirstOrDefault(dbUser => dbUser.Username == user.Username);
            if(dbUser != null)
            {
                if(PasswordHasher.CheckPassword(user.Password, dbUser.Password))
                {
                    return dbUser;
                }
            }
            return null;
        }
    }
}
