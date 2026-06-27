using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace WinUI3Template.Styles;

public partial class InverseBoolToVisibilityConverter : IValueConverter
{
	// For Mode=OneWay
	public object Convert(object value, Type targetType, object parameter, string language)
	  => (value is bool b && b) ? Visibility.Collapsed : Visibility.Visible;

	// For Mode=TwoWay
	public object ConvertBack(object value, Type targetType, object parameter, string language)
	  => (value is bool b && b) ? Visibility.Collapsed : Visibility.Visible;
}
