using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace WpfSimpleNavigationSample;

internal sealed partial class MainWindowViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;

    [ObservableProperty]
    private bool _canGoBack;

    public MainWindowViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;

        GoToChild1Command = new RelayCommand(() =>
        {
            navigationService.NavigateTo(RegionNames.Main, ViewNames.Child1);
            CanGoBack = navigationService.CanGoBack;
        });

        GoToChild2Command = new RelayCommand(() =>
        {
            navigationService.NavigateTo(RegionNames.Main, ViewNames.Child2);
            CanGoBack = navigationService.CanGoBack;
        });

        GoBackCommand = new RelayCommand(() =>
        {
            navigationService.TryNavigateBack();
            CanGoBack = navigationService.CanGoBack;
        });
    }

    public ICommand GoToChild1Command { get; }

    public ICommand GoToChild2Command { get; }

    public ICommand GoBackCommand { get; }

    public void PerformInitialNavigation()
    {
        _navigationService.NavigateTo(RegionNames.Main, ViewNames.Home);
    }
}
