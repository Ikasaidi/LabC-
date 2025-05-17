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

namespace IdeaManager.UI.Views
{
    public partial class MenuView : Page
    {
        public event Action<string> OnNavigate;

        public MenuView()
        {
            InitializeComponent();
        }

        private void IdeaList_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnNavigate?.Invoke("List");
        }

        private void IdeaForm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnNavigate?.Invoke("Form");
        }
    }
}
