using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml.Controls;

namespace WinUI3Template.Views.Pages;

public sealed partial class DetailsList_Page : Page
{
	public DetailsList_ViewModel ViewModel { get; }

	public DetailsList_Page()
	{
		ViewModel = Ioc.Default.GetRequiredService<DetailsList_ViewModel>();
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
