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
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<WorkoutProgress> WorkoutProgress { get; set; }

    }
}
