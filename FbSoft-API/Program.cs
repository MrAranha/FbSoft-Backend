using FbSoft_Services.Repositories;
using FbSoft_Services.Services;
using FbSoft_MediatrHandling.EntityRequests.Users.AutoMapper;
using FbSoft_MediatrHandling.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using FbSoft_MediatrHandling.EntityRequests.Users.Interfaces;
using FbSoft_Services.Queries.Users;
using static System.Net.Mime.MediaTypeNames;
using Scrutor;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Interfaces;
using FbSoft_Services.Queries.Empresas;
using FbSoft_Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<DbSession>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();

#region AddTransient
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IGetPagedUsersQuery, GetPagedUsersQuery>();
builder.Services.AddTransient<IGetPagedEmpresasQuery, GetPagedEmpresasQuery>();
#endregion

builder.Services.AddTransient<IFbSoftQuery, DottaQuery>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(IDefaultHandler).Assembly));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddCors(o => o.AddDefaultPolicy(
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:3000", "http://localhost:3043")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      }));

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
