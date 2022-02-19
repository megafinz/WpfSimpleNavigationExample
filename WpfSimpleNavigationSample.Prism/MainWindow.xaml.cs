using System.Windows;

namespace WpfSimpleNavigationSample;

internal sealed partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public MainWindow(MainWindowViewModel vm) : this()
    {
        DataContext = vm;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainWindowViewModel vm)
        {
            vm.PerformInitialNavigation();
        }
    }
}
