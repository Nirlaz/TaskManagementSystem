using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.TaskManagementSys.Application.Interfeces;
using TaskManagementSystem.TaskManagementSys.Application.Services;
using TaskManagementSystem.TaskManagementSys.Domain.Interfaces;
using TaskManagementSystem.TaskManagementSys.Infrastructure.Database;
using TaskManagementSystem.TaskManagementSys.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add services to Link With server = Localhost ; Trusted_Connection = True; TrustServerCertificate = true;
builder. Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer("Server = localhost; Database = TaskManagementDb; Trusted_Connection = True; TrustServerCertificate = true;"));

//Add services for Dependency Injection
builder.Services.AddScoped<IUserServices, UserServices>();
builder. Services. AddScoped<IUserRepository , UserRepository> ( );


builder.Services.AddScoped<IProjectServices, ProjectServices>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder. Services. AddScoped<ITaskServices , TaskServices> ( );
builder.Services.AddScoped<ITaskRepository, TaskRepository>();  

builder.Services.AddAutoMapper(typeof(Program));
builder. Services. AddCors ( options =>
{
    options. AddPolicy ( "AllowAll" ,
        policy => policy. AllowAnyOrigin ( )
                        . AllowAnyMethod ( )
                        . AllowAnyHeader ( ) );
} );





var app = builder.Build();

// Configure the HTTP request pipeline.

app. UseCors ( "AllowAll" );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
