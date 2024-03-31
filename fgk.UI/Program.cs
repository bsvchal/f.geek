using fgk.Application.Interfaces;
using fgk.Application.Services;
using fgk.Core.Abstractions;
using fgk.Core.Models;
using fgk.Infrastructure;
using fgk.Infrastructure.Options;
using fgk.Persistence;
using fgk.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace fgk.UI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<MovieDbContext>
            (
                options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MovieDbContext)));
                }
            );

            builder.Services.AddDbContext<AccountDbContext>
            (
                options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AccountDbContext)));
                }
            );

            builder.Services.AddSingleton<JwtOptions>();
            builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();

            builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
            builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();

            builder.Services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();
            
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IMovieService, MovieService>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:Key"]!))
                    };
                });
            
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}