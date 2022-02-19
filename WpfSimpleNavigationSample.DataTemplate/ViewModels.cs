using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Windows.Input;

namespace WpfSimpleNavigationSample;

internal abstract class ViewModelBase : ObservableObject
{
}

internal interface IChildViewModel
{
}

internal sealed class HomeViewModel : ViewModelBase, IChildViewModel
{
}

internal sealed class ChildViewModel1 : ViewModelBase, IChildViewModel
{
    public string Text => "Hey this is ChildViewModel1 speaking";
}

internal sealed class ChildViewModel2 : ViewModelBase, IChildViewModel
{
    public string Text => "Hey this is ChildViewModel2 speaking";
}

internal sealed partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private IChildViewModel _childVm = new HomeViewModel();

    [ObservableProperty]
    private bool _canGoBack;

    private readonly Stack<IChildViewModel> _navigationStack = new ();

    public MainWindowViewModel()
    {
        _navigationStack.Push(ChildVm);

        GoToChild1Command = new RelayCommand(() =>
        {
            ChildVm = new ChildViewModel1();
            _navigationStack.Push(ChildVm);
            UpdateCanGoBack();
        });

        GoToChild2Command = new RelayCommand(() =>
        {
            ChildVm = new ChildViewModel2();
            _navigationStack.Push(ChildVm);
            UpdateCanGoBack();
        });

        GoBackCommand = new RelayCommand(() =>
        {
            if (!CanGoBack) return;
            _navigationStack.Pop();
            ChildVm = _navigationStack.Peek();
            UpdateCanGoBack();
        });
    }

    public ICommand GoToChild1Command { get; }

    public ICommand GoToChild2Command { get; }

    public ICommand GoBackCommand { get; }

    private void UpdateCanGoBack() => CanGoBack = _navigationStack.Count > 1;
}
