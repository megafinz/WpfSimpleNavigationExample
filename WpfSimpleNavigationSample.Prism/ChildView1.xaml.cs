namespace WpfSimpleNavigationSample;

internal sealed partial class ChildView1
{
    public ChildView1()
    {
        InitializeComponent();
    }

    public ChildView1(ChildViewModel1 vm) : this()
    {
        DataContext = vm;
    }
}
