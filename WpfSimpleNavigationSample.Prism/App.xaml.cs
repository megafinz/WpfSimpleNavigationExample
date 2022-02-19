using Prism.Ioc;
using System.Windows;

namespace WpfSimpleNavigationSample;

internal sealed partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<HomeView>();
        containerRegistry.RegisterForNavigation<ChildView1>();
        containerRegistry.RegisterForNavigation<ChildView2>();
    }

    protected override Window CreateShell() => Container.Resolve<MainWindow>();
}
