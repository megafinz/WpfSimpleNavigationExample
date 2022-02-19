namespace WpfSimpleNavigationSample;

internal sealed partial class ChildView2
{
    public ChildView2()
    {
        InitializeComponent();
    }

    public ChildView2(ChildViewModel2 vm) : this()
    {
        DataContext = vm;
    }
}
