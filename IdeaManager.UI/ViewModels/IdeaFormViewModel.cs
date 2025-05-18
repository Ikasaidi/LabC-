using IdeaManager.Core.Entities;
using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaFormViewModel : ObservableObject
    {
        private readonly IIdeaService _ideaService;
        private readonly IdeaListViewModel _ideaListViewModel;

        public IdeaFormViewModel(IIdeaService ideaService, IdeaListViewModel ideaListViewMode)
        {
            _ideaService = ideaService;
            _ideaListViewModel = ideaListViewMode;
        }

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty]
        private string confirmationMessage;

        [RelayCommand]
        private async Task SubmitAsync()
        {
            try
            {
                var idea = new Idea
                {
                    Title = Title,
                    Description = Description
                };

                await _ideaService.SubmitIdeaAsync(idea);
                ErrorMessage = string.Empty;
     
                ConfirmationMessage = "Idée envoyée avec succès";

                Title = string.Empty;
                Description = string.Empty;
                await _ideaListViewModel.LoadIdeasAsync();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}

