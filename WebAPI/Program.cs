using Application.Auth.Commands.Register;
using Application.Chat.Handlers;
using Application.Chat.Interfaces;
using Application.Chat.Mapping;
using Application.Interfaces;
using Application.Notifications.Interfaces;
using Application.SchoolClasses.Handlers;
using Application.SchoolClasses.Mapping;
using Application.Teams.Mapping;
using Application.Users.Handlers;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using WebAPI.Middleware;
using Supabase;
using WebAPI.Hubs;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton(provider => 
    new Client(
        builder.Configuration["Supabase:Url"]!,
        builder.Configuration["Supabase:Key"],
        new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        }
    )
);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


//los repositories
builder.Services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IInfoUserRepository, InfoUserRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();


//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly)); // Escanea Handlers en Application
// En Program.cs
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllSchoolClassByUserIdHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAllUsersHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(LoginHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(RegisterHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(SendMessageHandler).Assembly);
    // Agrega más assemblies si tienes handlers en otros proyectos
});

builder.Services.AddAutoMapper(typeof(SchoolClassProfile)); 
builder.Services.AddAutoMapper(typeof(TeamProfile));
builder.Services.AddAutoMapper(typeof(ActivityProfile)); 
builder.Services.AddAutoMapper(typeof(ChatProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
builder.Services.AddScoped<IRealTimeNotifier, RealTimeNotifier>();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapHub<WizerbHub>("/hubs/wizer");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();