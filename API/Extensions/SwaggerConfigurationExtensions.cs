using Core.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace API.Extensions
{
    public static class SwaggerConfigurationExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.ExampleFilters();
            });

            services.AddSwaggerExamplesFromAssemblyOf<CreateUserDTO>();

            return services;
        }
    }
}
