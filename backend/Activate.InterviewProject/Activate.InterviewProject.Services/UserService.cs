using Activate.InterviewProject.Core.Interfaces;
using Activate.InterviewProject.Core.Models;
using Activate.InterviewProject.Core.Models.Authentication;
using Activate.InterviewProject.Services.Auth;
using Activate.InterviewProject.Services.Interfaces;
using Activate.InterviewProject.Services.Mappers;

namespace Activate.InterviewProject.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        private UserMapper _mapper;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new UserMapper();
        }

        public async Task<bool> CreateUser(RegisterModel user)
        {
            if (user == null) throw new ArgumentNullException(nameof (user));
            AppUser appUser = new AppUser(
                user.Username,
                PasswordHasher.HashPassword(user.Password),
                user.Email,
                user.Role
              );

            var dbUser = _unitOfWork.Users.GetAll().Result.FirstOrDefault(dbUser => dbUser.Username == user.Username);
            if(dbUser != null)
            {
                return false;
            }
            await _unitOfWork.Users.Add(appUser);
            var result = _unitOfWork.Save();

            return Convert.ToBoolean(result);
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            if (userId == Guid.Empty) throw new ArgumentNullException(nameof(userId));
            var userDetails = await _unitOfWork.Users.GetById(userId);
            _unitOfWork.Users.Delete(userDetails);
            var result = _unitOfWork.Save();
            return Convert.ToBoolean(result);
        }

        public async Task<AppUser> GetUserById(Guid userId)
        {
            if (userId == Guid.Empty) throw new ArgumentNullException(nameof(userId));
            var user = await _unitOfWork.Users.GetById(userId);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _unitOfWork.Users.GetAll();
            return _mapper.Map(users);
        }

        public async Task<IEnumerable<User>> GetNormalUsers()
        {
            var users = await _unitOfWork.Users.GetNormalUsers();
            return _mapper.Map(users);
        }

        public async Task<IEnumerable<User>> GetAdminUsers()
        {
            var users = await _unitOfWork.Users.GetAdminUsers();
            return _mapper.Map(users);
        }

        public async Task<bool> UpdateUser(AppUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var userDetails = await _unitOfWork.Users.GetById(user.Id);
            if (userDetails == null) throw new NullReferenceException(nameof(userDetails));

            userDetails.Username = user.Username;
            userDetails.Email = user.Email;
            userDetails.Password = userDetails.Password;
            userDetails.Role = user.Role;

            _unitOfWork.Users.Update(userDetails);
            var result = _unitOfWork.Save();
            return Convert.ToBoolean(result);
        }

        public async Task<bool> UpdateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var userDetails = await _unitOfWork.Users.GetById(Guid.Parse(user.Id));
            if (userDetails == null) throw new NullReferenceException(nameof(userDetails));

            userDetails.Username = user.Username;
            userDetails.Email = user.Email;
            userDetails.Role = user.Role;

            _unitOfWork.Users.Update(userDetails);
            var result = _unitOfWork.Save();
            return Convert.ToBoolean(result);
        }

        public async Task<IEnumerable<UserRoles>> GetAllUserRoles()
        {
            // Fetch all users from the unit of work
            var users = await _unitOfWork.Users.GetAll();

            // Use a HashSet to ensure unique roles without requiring Distinct()
            var roles = new HashSet<(string Value, string Name)>();

            foreach (var user in users)
            {
                //null or empty values set to user 
                if (string.IsNullOrEmpty(user?.Role) || user.Role.Equals("user", StringComparison.OrdinalIgnoreCase))
                {
                    roles.Add(("user", "User"));
                }
                if (!string.IsNullOrEmpty(user?.Role) && user.Role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    roles.Add(("admin", "Administrator"));
                }
            }

            // Map each unique role to a UserRoles instance
            return roles.Select(role => new UserRoles
            {
                Id = Guid.NewGuid().ToString(),
                Value = role.Value,
                Name = role.Name
            });
        }
    }
}
