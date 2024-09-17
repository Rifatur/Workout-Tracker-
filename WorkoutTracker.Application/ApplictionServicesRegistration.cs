using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WorkoutTracker.Application
{
    public static class ApplictionServicesRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
