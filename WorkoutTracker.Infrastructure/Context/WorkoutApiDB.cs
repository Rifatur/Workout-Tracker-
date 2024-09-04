using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Core.Entities;

namespace WorkoutTracker.Infrastructure.Context
{
    public class WorkoutApiDB : IdentityDbContext<IdentityUser>
    {
        public WorkoutApiDB(DbContextOptions<WorkoutApiDB> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
