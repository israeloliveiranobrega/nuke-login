using Microsoft.EntityFrameworkCore;
using NukeLogin.Src.Features.AccessControl.JasonWebToken;
using NukeLogin.Src.Infrastructure;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Contracts;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Implementation;
using NukeLogin.Src.Shared.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SafePlaceConnection");

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

#region Dependencies injection
//builder.Services.AddApplication(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IJwtProvider,JwtProvider>();
builder.Services.AddScoped<IUserAgentServices, UserAgentServices>();
builder.Services.AddTransient<IUserSessionRepository,UserSessionRepository>();
builder.Services.AddTransient<IUserRepository,UserRepository>();
#endregion

#region Controllers and Swagger
builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Base
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion

//services.AddMediatR(cfg =>
//{
//    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
//    cfg.AddOpenBehavior(typeof(ValidUserBehavior<,>));
//    cfg.AddOpenBehavior(typeof(SendEmailBehavior<,>));
//    cfg.AddOpenBehavior(typeof(LogBehavior<,>));//ordem de adiçãoo implica na ordem de execução deles
//});

//var command = new CreateUserCommand
//{
//    Name = Console.ReadLine() ?? string.Empty
//};