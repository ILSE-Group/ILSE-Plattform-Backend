using Domain.IRepositories.ILevelRepositories;
using Domain.IRepositories.IOTPRepositories;
using Domain.IRepositories.IProgressRepositories;
using Domain.IRepositories.IRoomRepositories;
using Domain.IRepositories.ITopicRepositories;
using Domain.IRepositories.IUserRepositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.ProgressRepository;
using Persistence.Repositories.TopicRepositories;
using Persistence.Repositories.UserRepositories;
using Persistence.Repositories.UserRepository.UserRepository;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
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
