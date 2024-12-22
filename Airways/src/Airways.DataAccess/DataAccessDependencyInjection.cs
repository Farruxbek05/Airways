﻿using Airways.DataAccess.Identity;
using Airways.DataAccess.Persistence;
using Airways.DataAccess.Repository;
using Airways.DataAccess.Repository.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airways.DataAccess
{
    public static class DataAccessDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);

            services.AddIdentity();

            services.AddRepositories();

            return services;
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAircraftRepository, AicraftRepository>();
            services.AddScoped<IAirlineRepository,Airlinerepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>(); 
            services.AddScoped<IPaymentRepository,PaymentRepository>();
            services.AddScoped<IPricePolyceRepository,PricePolicyRepository>();
            services.AddScoped<IReviewRepository,ReviewRepository>();
            services.AddScoped<IReysRepository,ReysRepository>();
            services.AddScoped<ITicketRepository,TicketRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();

            if (databaseConfig.UseInMemoryDatabase)
                services.AddDbContext<DataBaseContext>(options =>
                {
                    options.UseInMemoryDatabase("AirwaysDatabase");
                    options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                });
            else
                services.AddDbContext<DataBaseContext>(options =>
                    options.UseNpgsql(databaseConfig.ConnectionString,
                        opt => opt.MigrationsAssembly(typeof(DataBaseContext).Assembly.FullName)));
        }

        private static void AddIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataBaseContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
        }
    }

    // TODO move outside?
    public class DatabaseConfiguration
    {
        public bool UseInMemoryDatabase { get; set; }

        public string ConnectionString { get; set; }
    }

}