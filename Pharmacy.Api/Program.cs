
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Data;
using Repository;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var con = builder.Configuration.GetConnectionString("con");
        builder.Services.AddDbContext<OnlinePharmacyDbContext>(options => options.UseSqlServer(con));
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
