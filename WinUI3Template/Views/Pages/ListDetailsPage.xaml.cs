using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml.Controls;

namespace WinUI3Template.Views.Pages;

public sealed partial class ListDetailsPage : Page
{
    public ListDetailsPageViewModel ViewModel { get; }

    public ListDetailsPage()
    {
        ViewModel = Ioc.Default.GetRequiredService<ListDetailsPageViewModel>();
        DataContext = ViewModel;
        InitializeComponent();
    }

    private void OnViewStateChanged(object sender, ListDetailsViewState e)
    {
        if (e == ListDetailsViewState.Both)
        {
            ViewModel.EnsureItemSelected();
        }
    }
}
