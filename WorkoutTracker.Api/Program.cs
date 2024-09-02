using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Services.Implementation;
using WorkoutTracker.Application.Services.Interfaces;
using WorkoutTracker.Core.Entities;
using WorkoutTracker.Core.Intefaces;
using WorkoutTracker.Infrastructure.Context;
using WorkoutTracker.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WorkoutApiDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WorkoutDBConnection")));


builder.Services
    .AddIdentityApiEndpoints<AppUser>()
    .AddEntityFrameworkStores<WorkoutApiDB>();

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<WorkoutApiDB>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.MapGroup("/api").MapIdentityApi<AppUser>();

app.Run();
