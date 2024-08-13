using Microsoft.EntityFrameworkCore;
using ConstructionManagement.Infrastructure;
using ConstructionManagement.Application.Abstration;
using ConstructionManagement.Infrastructure.Repositories;
using ConstructionManagement.Application.Managers;
using ConstructionManagement.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using ConstructionManagement.Application.Services;

var builder = WebApplication.CreateBuilder(args);






builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IActivityService, ActivityRepository>();
builder.Services.AddScoped<IWorkerService, WorkerRepository>();

builder.Services.AddScoped<IUserService, UserServiceManager>();

builder.Services.AddScoped<IActivityBussiniessService, ActivityManager>();
builder.Services.AddScoped<IWorkerBussinessService, WorkerManager>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<AppUser, IdentityRole>().
    AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer("Bearer", options =>
{
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new ()
    {
        ValidateIssuer = true, // oluþturulacak token deðerinin kimlerin /hangi orginlerin sitelerin kullanacaðý deðerlerdir.
        ValidateAudience = true,  //oluþturulacak token deðerini kimin daðýttýðýný 
        ValidateLifetime = true,//oluþuturulan token deðerinin süresini kontrol eden özellik. 
        ValidateIssuerSigningKey = true,//üretilecek token key deðerinin  uygulamamýza ait bir deðer olduðunu ifade ederr. 
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            
    };
});

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
            policy.WithOrigins("http://localhost:7291", "https://localhost:7291").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));



builder.Services.AddControllers();
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.



app.UseRouting();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run();

