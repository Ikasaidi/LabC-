using IdeaManager.Data;
using IdeaManager.Services;
using IdeaManager.UI.ViewModels;
using IdeaManager.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace IdeaManager.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    //centraliser l’appel des 3 méthodes d’extension
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();

        services.AddDataServices("Data Source=ideas_fixed.db");
        services.AddDomainServices();
        services.AddUIServices();

        //Navigation bcp plus simple 
        services.AddTransient<IdeaFormViewModel>();
        services.AddTransient<IdeaListViewModel>();
        services.AddTransient<MenuViewModel>();


        services.AddTransient<IdeaFormView>();
        services.AddTransient<IdeaListView>();
        services.AddTransient<MenuView>();

        
        services.AddSingleton<MainWindow>();

        ServiceProvider = services.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}

