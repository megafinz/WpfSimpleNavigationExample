using Prism.Regions;
using System;
using System.Collections.Generic;

namespace WpfSimpleNavigationSample;

internal sealed class NavigationService
{
    private readonly IRegionManager _regionManager;
    private readonly Stack<(string Region, string View)> _navigationStack = new();

    public NavigationService(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    public void NavigateTo(string regionName, string viewName)
    {
        _regionManager.RequestNavigate(regionName, new Uri(viewName, UriKind.Relative));
        _navigationStack.Push((regionName, viewName));
    }

    public void TryNavigateBack()
    {
        if (!CanGoBack) return;
        _navigationStack.Pop();
        var (region, view) = _navigationStack.Peek();
        _regionManager.RequestNavigate(region, new Uri(view, UriKind.Relative));
    }

    public bool CanGoBack => _navigationStack.Count > 1;
}
