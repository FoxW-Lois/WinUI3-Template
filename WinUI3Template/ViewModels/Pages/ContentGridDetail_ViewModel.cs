using CommunityToolkit.Mvvm.ComponentModel;

namespace WinUI3Template.ViewModels.Pages;

public partial class ContentGridDetail_ViewModel : ObservableRecipient, INavigationAware
{
	private readonly ISampleDataService _sampleDataService;

	[ObservableProperty]
	private SampleOrder? item;

	public ContentGridDetail_ViewModel(ISampleDataService sampleDataService)
	{
		_sampleDataService = sampleDataService;
	}

	public async void OnNavigatedTo(object parameter)
	{
		if (parameter is long orderID)
		{
			var data = await _sampleDataService.GetContentGridDataAsync();
			Item = data.First(i => i.OrderID == orderID);
		}
	}

	public void OnNavigatedFrom()
	{
	}
}
