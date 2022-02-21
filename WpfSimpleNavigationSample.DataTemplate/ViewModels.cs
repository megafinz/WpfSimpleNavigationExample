using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;

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
    }

    [ICommand]
    private void GoToChild1()
    {
        _navigationStack.Push(ChildVm = new ChildViewModel1());
        UpdateCanGoBack();
    }

    [ICommand]
    private void GoToChild2()
    {
        _navigationStack.Push(ChildVm = new ChildViewModel1());
        UpdateCanGoBack();
    }

    [ICommand]
    private void GoBack()
    {
        if (!CanGoBack) return;
        _navigationStack.Pop();
        ChildVm = _navigationStack.Peek();
        UpdateCanGoBack();
    }

    private void UpdateCanGoBack() => CanGoBack = _navigationStack.Count > 1;
}
