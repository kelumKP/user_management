using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activate.InterviewProject.Core.Models;

namespace Activate.InterviewProject.Infrastructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<AppUser> Users { get; set; }
        public bool IsDisposed { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Users
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser("fry", null, "fry@planetexpress.com", null) { Id = Guid.NewGuid(), Password = Guid.NewGuid().ToString() },
                new AppUser("leela", null, "leela@planetexpress.com", null) { Id = Guid.NewGuid(), Password = Guid.NewGuid().ToString() },
                new AppUser("bender", null, "bender@planetexpress.com", null) { Id = Guid.NewGuid(), Password = Guid.NewGuid().ToString() },
                new AppUser("professor", null, "farnsworth@planetexpress.com", "admin") { Id = Guid.NewGuid(), Password = Guid.NewGuid().ToString() },
                new AppUser("amy", null, "amy@planetexpress.com", null) { Id = Guid.NewGuid(), Password = Guid.NewGuid().ToString() },
                new AppUser("hermes", null, "hermes@planetexpress.com", null) { Id = Guid.NewGuid(), Password = Guid.NewGuid().ToString() },
                new AppUser("zoidberg", null, "zoidberg@planetexpress.com", null) { Id = Guid.NewGuid(), Password = Guid.NewGuid().ToString() },
                new AppUser("zapp", null, "zapp@doop.com", null) { Id = Guid.NewGuid(), Password = Guid.NewGuid().ToString() },
                new AppUser("kif", null, "kif@doop.com", null) { Id = Guid.NewGuid(), Password = Guid.NewGuid().ToString() },
                new AppUser("mom", null, "mom@momcorp.com", null) { Id = Guid.NewGuid(), Password = Guid.NewGuid().ToString() }
            );
        }
    }
}
