using Domain.IRepositories.ILevelRepositories;
using Domain.IRepositories.IOTPRepositories;
using Domain.IRepositories.IProgressRepositories;
using Domain.IRepositories.IRoomRepositories;
using Domain.IRepositories.ITopicRepositories;
using Domain.IRepositories.IUserRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Identity;
using Persistence.Repositories.ProgressRepository;
using Persistence.Repositories.TopicRepositories;
using Persistence.Repositories.UserRepositories;
using Persistence.Repositories.UserRepository.UserRepository;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment env)
        {
            services.AddDatabaseContext(configuration, env);
            services.AddRepositories();
            services.AddIdentityServices();

            return services;
        }

        private static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection AddDatabaseContext(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment env)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                if (env.IsDevelopment() || env.IsEnvironment("Testing"))
                {
                    options.UseSqlite(
                        configuration.GetConnectionString("SqliteConnection")
                        ?? "Data Source=ilse.db");
                }
                else
                {
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                }
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IExerciseProgressRepository, ExerciseProgressRepository>();
            services.AddScoped<IRoomProgressRepository, RoomProgressRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOTPRepository, OTPRepository>();

            return services;
        }
    }
}