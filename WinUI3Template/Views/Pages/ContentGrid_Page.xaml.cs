using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace WinUI3Template.Views;

public sealed partial class ContentGrid_Page : Page
{
    public ContentGrid_ViewModel ViewModel { get; }

    public ContentGrid_Page()
    {
        ViewModel = Ioc.Default.GetRequiredService<ContentGrid_ViewModel>();
        DataContext = ViewModel;
        InitializeComponent();
    }
}
