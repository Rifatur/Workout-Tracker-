using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WorkoutTracker.Infrastructure.Context
{
    public class WorkoutApiDB : IdentityDbContext
    {
        public WorkoutApiDB(DbContextOptions<WorkoutApiDB> options) : base(options) { }


    }
}
