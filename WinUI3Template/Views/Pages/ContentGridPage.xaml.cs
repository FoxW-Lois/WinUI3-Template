using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace WinUI3Template.Views;

public sealed partial class ContentGridPage : Page
{
    public ContentGridViewModel ViewModel { get; }

    public ContentGridPage()
    {
        ViewModel = Ioc.Default.GetRequiredService<ContentGridViewModel>();
        DataContext = ViewModel;
        InitializeComponent();
    }
}
