using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using FluentValidation;
using Service.DTOs.Admin.Countries;
using Service.Helpers;
using Service.Services.Interface;
using Service.Services;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();

            services.AddScoped<IValidator<CountryCreateDto>, CountryCreateDtoValidator>();
            return services;
        }

    }
}
