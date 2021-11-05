using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GamePassBrowser.Core.MVVM.Model;

namespace GamePassBrowser.Core.MVVM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private CancellationTokenSource _cts;
        private bool _isLoading;
        public ObservableCollection<DesktopGameViewModel> DesktopGames { get; private set; }

        public MainWindowViewModel()
        {
            Task.Run(LoadGameLibraryAsync);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => TryUpdateAndNotify(ref _isLoading, value);
        }

        public async Task LoadGameLibraryAsync()
        {
            IsLoading = true;
            DesktopGame[] gameModels = await MicrosoftStoreApi.GetAllDesktopGames(GetTokenAndCancelExistingJobs());
            IEnumerable<DesktopGameViewModel> gameViewModels = gameModels.Select(x => new DesktopGameViewModel(x));
            DesktopGames = new ObservableCollection<DesktopGameViewModel>(gameViewModels);
            IsLoading = false;
            OnPropertyChanged(nameof(DesktopGames));
        }

        private CancellationToken GetTokenAndCancelExistingJobs()
        {
            if (_cts == null)
                _cts = new CancellationTokenSource();
            else if (_cts.IsCancellationRequested)
                _cts.Cancel();
            
            return _cts.Token;
        }
    }
}