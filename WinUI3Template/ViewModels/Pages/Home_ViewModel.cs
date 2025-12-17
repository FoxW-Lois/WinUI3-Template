using CommunityToolkit.Mvvm.ComponentModel;

namespace WinUI3Template.ViewModels.Pages;

public partial class Home_ViewModel : ObservableRecipient
{
    [ObservableProperty]
    public partial string AppDisplayName { get; set; } = ConstantHelper.AppDisplayName;

    public Home_ViewModel()
    {

    }
}
