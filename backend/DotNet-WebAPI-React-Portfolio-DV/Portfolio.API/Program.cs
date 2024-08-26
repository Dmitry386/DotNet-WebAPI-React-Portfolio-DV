
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Services;
using Portfolio.Core.Abstractions;
using Portfolio.DataAccess;
using Portfolio.DataAccess.Repositories;

namespace Portfolio.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
             
            builder.Services.AddControllers(); 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<PortfolioDbContext>(
                options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(PortfolioDbContext)));
            });

            builder.Services.AddScoped<IPortfoliosService, PortfolioService>();
            builder.Services.AddScoped<IPortfoliosRepository, PortfoliosRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization(); 

            app.MapControllers();

            app.UseCors(options =>
            {
                options.WithHeaders().AllowAnyHeader();
                options.WithOrigins("http://localhost:3000");
                options.WithMethods().AllowAnyMethod();
            });

            app.Run();
        }
    }
}