using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activate.InterviewProject.Core.Interfaces;
using Activate.InterviewProject.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Activate.InterviewProject.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(DbContextClass dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<AppUser>> GetNormalUsers()
        {
            return _dbContext.Users.FromSqlRaw(@"SELECT * FROM ""Users"" u WHERE u.""Role"" <> 'admin' OR u.""Role"" IS NULL");
        }

        public async Task<IEnumerable<AppUser>> GetAdminUsers()
        {
            return _dbContext.Users.FromSqlRaw($@"SELECT * FROM ""Users"" u where u.""Role"" = 'admin'");
        }
    }
}
