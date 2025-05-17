using IdeaManager.Core.Interfaces;
using IdeaManager.Services;
using IdeaManager.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IdeaManager.Services
{
    //branche l’interface IIdeaService à IdeaServic
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IIdeaService, IdeaService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}