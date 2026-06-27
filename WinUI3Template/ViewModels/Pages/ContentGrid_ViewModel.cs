using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WinUI3Template.ViewModels.Pages;

public partial class ContentGrid_ViewModel : ObservableRecipient, INavigationAware
{
	private readonly INavigationService _navigationService;
	private readonly ISampleDataService _sampleDataService;

	public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

	public ContentGrid_ViewModel(INavigationService navigationService, ISampleDataService sampleDataService)
	{
		_navigationService = navigationService;
		_sampleDataService = sampleDataService;
	}

	public async void OnNavigatedTo(object parameter)
	{
		Source.Clear();

		// TODO: Replace with real data.
		var data = await _sampleDataService.GetContentGridDataAsync();
		foreach (var item in data)
		{
			Source.Add(item);
		}
	}

	public void OnNavigatedFrom()
	{
	}

	[RelayCommand]
	private void OnItemClick(SampleOrder? clickedItem)
	{
		if (clickedItem != null)
		{
			_navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
			_navigationService.NavigateTo(typeof(ContentGridDetail_ViewModel).FullName!, clickedItem.OrderID);
		}
	}
}
