namespace WpfSimpleNavigationSample;

internal sealed partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}
