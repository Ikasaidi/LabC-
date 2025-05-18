using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IdeaManager.UI.ViewModels;
using IdeaManager.UI.Views;


namespace IdeaManager.UI
{
    public partial class MainWindow : Window
    {

        //Ramener les vue 
        private readonly IdeaFormView _ideaFormView;
        private readonly IdeaListView _ideaListView;
        private readonly MenuView _menuView;
        public MainWindow(IdeaFormView ideaFormView, IdeaListView ideaListView, MenuView menuView)
            {
            InitializeComponent();

            // Injecte les vues
            _ideaFormView = ideaFormView;
            _ideaListView = ideaListView;
            _menuView = menuView;

            // Relie la navigation à la méthode locale
            ((MenuViewModel)_menuView.DataContext).OnNavigate += NavigateTo;

            // Place les vues dans l'interface
            MenuPlaceholder.Content = _menuView;
            MainContent.Content = _ideaListView; // vue par défaut
        }

        public void NavigateTo(String view)
        {
            switch (view)
            {
                case "Form":
                    MainContent.Content = _ideaFormView;
                    break;
                case "List":
                    MainContent.Content = _ideaListView;
                    break;
                
            }
        }

    }
}
