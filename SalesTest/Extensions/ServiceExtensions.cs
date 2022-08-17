using Data;
using Microsoft.Extensions.DependencyInjection;
using Models.Interfaces.Data;
using Models.Interfaces.Repository;
using Repository;

namespace SalesTest.Extensions
{
    public static class ServiceExtensions
    {
        #region Implementacion de cors
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {

                options.AddPolicy("CorsPolicy",

                    builder =>

                    {

                        builder.AllowAnyOrigin()

                        .AllowAnyMethod()

                        .AllowAnyHeader();

                    });

            });

        }
        #endregion

        #region Implementacion de las dependencias
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<ISalesData, SalesData>();
        }
        #endregion
    }
}
