using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace IdeaManager.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour IdeaListView.xaml
    /// </summary>
    public partial class IdeaListView : UserControl
    {
        private readonly IdeaListViewModel _vm;

        public IdeaListView(IdeaListViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            DataContext = vm;

            //Permet de mettre les bonnes données à chaque affichage pour une méthode async 
            Loaded += async (_, __) => await _vm.LoadIdeasAsync();
        }
    }
}
