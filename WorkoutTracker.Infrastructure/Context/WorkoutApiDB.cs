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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Exercise>().HasData(
        //        new Exercise { Id = Guid.NewGuid(), Name = "Push-Up", Description = "Push-Up exercise", Category = "Strength", MuscleGroup = "Chest" },
        //        new Exercise { Id = Guid.NewGuid(), Name = "Squat", Description = "Squat exercise", Category = "Strength", MuscleGroup = "Legs" }
        //        // Add more exercises
        //    );
        //}

    }
}
