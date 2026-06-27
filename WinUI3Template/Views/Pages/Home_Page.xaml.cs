using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace WinUI3Template.Views.Pages;

public sealed partial class Home_Page : Page
{
	public Home_ViewModel ViewModel { get; }

	public Home_Page()
	{
		ViewModel = Ioc.Default.GetRequiredService<Home_ViewModel>();
		DataContext = ViewModel;
		InitializeComponent();
	}
}
