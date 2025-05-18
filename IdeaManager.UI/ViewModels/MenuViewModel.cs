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
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IdeaManager.UI.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        public event Action<string>? OnNavigate;


        [RelayCommand]
        private void GoToList()
        {
            OnNavigate?.Invoke("List");
        }

        [RelayCommand]

        private void GoToForm()
        {
            OnNavigate?.Invoke("Form");
        }
    }
}
