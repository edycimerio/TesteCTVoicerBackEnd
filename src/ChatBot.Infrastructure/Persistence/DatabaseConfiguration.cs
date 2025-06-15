using ChatBot.Domain.Interfaces;
using ChatBot.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatBot.Infrastructure.Persistence
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Obter a configuração do serviço provider
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            // Configurar o DbContext com PostgreSQL
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            // Registrar repositórios
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            
            // Registrar Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
