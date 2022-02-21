using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfSimpleNavigationSample;

internal sealed partial class MainWindowViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;

    [ObservableProperty]
    private bool _canGoBack;

    public MainWindowViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [ICommand]
    private void GoToChild1()
    {
        _navigationService.NavigateTo(RegionNames.Main, ViewNames.Child1);
        CanGoBack = _navigationService.CanGoBack;
    }

    [ICommand]
    private void GoToChild2()
    {
        _navigationService.NavigateTo(RegionNames.Main, ViewNames.Child2);
        CanGoBack = _navigationService.CanGoBack;
    }

    [ICommand]
    private void GoBack()
    {
        _navigationService.TryNavigateBack();
        CanGoBack = _navigationService.CanGoBack;
    }

    public void PerformInitialNavigation()
    {
        _navigationService.NavigateTo(RegionNames.Main, ViewNames.Home);
    }
}
