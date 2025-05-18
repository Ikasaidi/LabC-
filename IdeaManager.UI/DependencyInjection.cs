using IdeaManager.UI.ViewModels;
using IdeaManager.UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace IdeaManager.UI
{
    // enregistre les ViewModels pour qu’ils puissent être injectés dans les vues
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<IdeaFormViewModel>();
            services.AddTransient<ProjectListViewModel>();
            services.AddTransient<IdeaFormView>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MenuView>();
            services.AddSingleton<IdeaListView>();
            services.AddSingleton<IdeaListViewModel>();

            return services;
        }
    }
}