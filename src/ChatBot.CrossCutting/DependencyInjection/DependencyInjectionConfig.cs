using ChatBot.Application.Services.BotResponse;
using ChatBot.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChatBot.CrossCutting.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Layer
            RegisterApplicationServices(services);

            // Domain Layer
            RegisterDomainServices(services);
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            // Bot Response Services
            services.AddScoped<IBotResponseService, BotResponseService>();
            services.AddScoped<IBotResponseStrategyFactory, BotResponseStrategyFactory>();
            
            // Bot Response Strategies
            services.AddTransient<IBotResponseStrategy, GreetingResponseStrategy>();
            services.AddTransient<IBotResponseStrategy, QuestionResponseStrategy>();
            services.AddTransient<IBotResponseStrategy, DefaultResponseStrategy>();

            // MediatR Registration
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
                typeof(Application.Commands.StartConversation.StartConversationCommand).Assembly));
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            // Domain Services (se houver)
        }
    }
}
