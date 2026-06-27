using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace WinUI3Template.Views.Pages;

public sealed partial class Settings_Page : Page
{
	public Settings_ViewModel ViewModel { get; }

	public Settings_Page()
	{
		ViewModel = Ioc.Default.GetRequiredService<Settings_ViewModel>();
		DataContext = ViewModel;
		InitializeComponent();
	}
}
