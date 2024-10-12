
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using REST_03_EF_ferramenta.Models;
using REST_03_EF_ferramenta.Repositories;
using REST_03_EF_ferramenta.Services;

namespace REST_03_EF_ferramenta
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
            #region
#if DEBUG
            builder.Services.AddDbContext<ContextFerramenta>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest"))
                );

            builder.Services.AddScoped<ProdottoRepository>();
            builder.Services.AddScoped<RepartoRepository>();
            builder.Services.AddScoped<ProdottoService>();
            builder.Services.AddScoped<RepartoService>();
            builder.Services.AddScoped<ProdRepaService>();


#else      
                builder.Services.AddDbContext<ContextFerramenta>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseProd"))
                );

#endif
            #endregion




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors(builder =>
                 builder
                 .WithOrigins("*")
                 .AllowAnyMethod()
                 .AllowAnyHeader());

            app.Run();
        }
    }
}
