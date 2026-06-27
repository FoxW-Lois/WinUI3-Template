using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WinUI3Template.ViewModels.Pages;

public partial class DataGrid_ViewModel : ObservableRecipient, INavigationAware
{
	private readonly ISampleDataService _sampleDataService;

	public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

	public DataGrid_ViewModel(ISampleDataService sampleDataService)
	{
		_sampleDataService = sampleDataService;
	}

	public async void OnNavigatedTo(object parameter)
	{
		Source.Clear();

		// TODO: Replace with real data.
		var data = await _sampleDataService.GetGridDataAsync();

		foreach (var item in data)
		{
			Source.Add(item);
		}
	}

	public void OnNavigatedFrom()
	{
	}
}
