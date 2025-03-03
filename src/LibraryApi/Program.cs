
using LibraryApplication.Interfaces;
using LibraryApplication.Services;
using LibraryInfra.Connection;
using Microsoft.EntityFrameworkCore;
using MyProject.Mappings;
using Npgsql;

namespace LibraryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DbConnection>
                (options => options.UseNpgsql(connectionString, b => b.MigrationsAssembly("LibraryInfra")));

            builder.Services.AddScoped<IUserService, UseCaseUsers>();
            builder.Services.AddScoped<IBookService, UseCaseBooks>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
