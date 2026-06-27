namespace WinUI3Template.Contracts.Services;

public interface IDialogService
{
    Task ShowOneButtonDialogAsync(string title, string content);

    Task<WidgetDialogResult> ShowTwoButtonDialogAsync(string title, string content, string leftButton = null!, string rightButton = null!);

    Task<WidgetDialogResult> ShowThreeButtonDialogAsync(string title, string content, string leftButton = null!, string centerButton = null!, string rightButton = null!);

    Task ShowFullScreenOneButtonDialogAsync(string title, string content);

    Task<WidgetDialogResult> ShowFullScreenTwoButtonDialogAsync(string title, string content, string leftButton = null!, string rightButton = null!);

    Task<WidgetDialogResult> ShowFullScreenThreeButtonDialogAsync(string title, string content, string leftButton = null!, string centerButton = null!, string rightButton = null!);
}
