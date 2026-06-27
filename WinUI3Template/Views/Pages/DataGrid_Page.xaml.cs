using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace WinUI3Template.Views.Pages;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGrid_Page.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class DataGrid_Page : Page
{
	public DataGrid_ViewModel ViewModel { get; }

	public DataGrid_Page()
	{
		ViewModel = Ioc.Default.GetRequiredService<DataGrid_ViewModel>();
		DataContext = ViewModel;
		InitializeComponent();
	}
}
