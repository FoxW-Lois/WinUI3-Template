using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WinUI3Template.Views.Pages;

public sealed partial class DetailsList_DetailControl : UserControl
{
    public SampleOrder? DetailsListMenuItem
    {
        get => GetValue(DetailsListMenuItemProperty) as SampleOrder;
        set => SetValue(DetailsListMenuItemProperty, value);
    }

    public static readonly DependencyProperty DetailsListMenuItemProperty = DependencyProperty.Register("DetailsListMenuItem", typeof(SampleOrder), typeof(DetailsList_DetailControl), new PropertyMetadata(null, OnDetailsListMenuItemPropertyChanged));

    public DetailsList_DetailControl()
    {
        InitializeComponent();
    }

    private static void OnDetailsListMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is DetailsList_DetailControl control)
        {
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
