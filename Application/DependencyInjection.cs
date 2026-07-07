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
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IExerciseService, ExerciseService>();

            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
