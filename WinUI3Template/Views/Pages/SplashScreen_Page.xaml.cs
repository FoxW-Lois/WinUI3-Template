using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WinUI3Template.Views.Pages;

/// <summary>
/// Display the app splash screen.
/// Codes are edited from: <see href="https://github.com/files-community/Files"/>
/// </summary>
public sealed partial class SplashScreen_Page : Page
{
	private readonly string AppDisplayName = ConstantHelper.AppDisplayName;

	public SplashScreen_Page()
	{
		InitializeComponent();
		DataContext = this;
		App.MainWindow.ExtendsContentIntoTitleBar = true;
	}

	private void Image_ImageOpened(object sender, RoutedEventArgs e)
	{
		App.SplashScreenLoadingTCS?.TrySetResult();
	}

	private void Image_ImageFailed(object sender, RoutedEventArgs e)
	{
		App.SplashScreenLoadingTCS?.TrySetResult();
	}
}
