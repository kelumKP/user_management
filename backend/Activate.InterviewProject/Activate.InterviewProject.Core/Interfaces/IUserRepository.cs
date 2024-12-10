using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activate.InterviewProject.Core.Models;

namespace Activate.InterviewProject.Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        Task<IEnumerable<AppUser>> GetNormalUsers();
        Task<IEnumerable<AppUser>> GetAdminUsers();
    }
}
