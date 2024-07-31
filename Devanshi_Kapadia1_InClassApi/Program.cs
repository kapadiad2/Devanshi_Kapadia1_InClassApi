using AutoMapper;
using Devanshi_Kapadia1_InClassApi.Data;
using Devanshi_Kapadia1_InClassApi.Helpers;
using Devanshi_Kapadia1_InClassApi.Services;
using Microsoft.EntityFrameworkCore;

namespace Devanshi_Kapadia1_InClassApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Devanshi_KApadia
            // Setup AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile()); // Assuming your mapping profile is named MappingProfile
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            // Setup Database Context
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Devanshi_Kapadia1_InClassApi")));

    


            // Register services
            builder.Services.AddScoped<ICourseService, CourseService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline
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
}