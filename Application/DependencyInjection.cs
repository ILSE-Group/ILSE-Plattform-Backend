using Application.IServices.IProgressServices;
using Application.IServices.ITopicServices;
using Application.Services.ProgressServices;
using Application.IServices.IAuthServices;
using Application.IServices.ITopicServices;
using Application.Services.AuthServices;

using Application.Services.TopicServices;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Auth
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IAuthService, AuthService>();

            // Topics
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IExerciseService, ExerciseService>();

            // Progress
            services.AddScoped<IProgressService, ProgressService>();
            services.AddScoped<ILevelService, LevelService>();

            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}