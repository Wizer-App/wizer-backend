using Application.Interfaces;
using Application.SchoolClasses.Handlers;
using Application.SchoolClasses.Mapping;
using Application.Users.Handlers;
using Infrastructure.Data;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


//los repositories
builder.Services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
builder.Services.AddScoped<IUserRepository, IUserRepository>();

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly)); // Escanea Handlers en Application
// En Program.cs
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllSchoolClassByUserIdHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAllUsersHandler).Assembly);
    // Agrega más assemblies si tienes handlers en otros proyectos
});

builder.Services.AddAutoMapper(typeof(SchoolClassProfile)); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
