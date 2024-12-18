using Airways.Application.Common.Email;
using Airways.Application.Services.DevImpl;
using Airways.Application.Services.Impl;
using Airways.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Airways.Shared.Service;
using Airways.Shared.Service.Impl;
using Airways.Application.MappingProfiles;

namespace Airways.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnviroment env)
        {
            services.AddServices(env);

            services.RegisterAutoMapper();

            services.RegisterCashing();

            return services;
        }

        private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ITemplateService, TemplateService>();

            if (env.IsDevelopment())
                services.AddScoped<IEmailService, DevEmailService>();
            else
                services.AddScoped<IEmailService, EmailService>();
        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IMappingProfilesMarker));
        }

        private static void RegisterCashing(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }

        public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
        }
    }

}
