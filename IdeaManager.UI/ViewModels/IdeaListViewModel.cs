using CommunityToolkit.Mvvm.ComponentModel;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaListViewModel : ObservableObject
    {
        private readonly IIdeaService _ideaService;

        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
            LoadIdeas();
        }

        [ObservableProperty]
        private ObservableCollection<Idea> ideas = new();

        private async void LoadIdeas()
        {
            var list = await _ideaService.GetAllAsync();
            Ideas = new ObservableCollection<Idea>(list);
        }
    }
}
