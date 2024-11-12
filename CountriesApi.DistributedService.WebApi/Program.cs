using CountriesApi.Infrastructure.Contracts;
using CountriesApi.Infrastructure.Impl;
using CountriesApi.Library.Contracts;
using CountriesApi.Library.Impl;

namespace CountriesApi.DistributedService.WebApi
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

            // CountryRepository y CountryService
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();

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
}