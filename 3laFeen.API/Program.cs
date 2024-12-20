using _3laFeen.Infrastructure;
using _3laFeen.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using _3laFeen.API;
using Microsoft.AspNetCore.Identity;
using _3laFeen.Domain.IRepositories;
using _3laFeen.Infrastructure.Repositories;

namespace _3laFeen.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<_3laFeenDbContext>(
options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")) );
           builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRouteRepository , RouteRepository>();
            builder.Services.AddAuthentication();
            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<_3laFeenDbContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapIdentityApi<IdentityUser>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
