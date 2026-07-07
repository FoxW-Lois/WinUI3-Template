using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SuGarToolkit.Controls.Dialogs;

namespace WinUI3Template.Services;

public class DialogService : IDialogService
{
	private readonly string Ok = "ButtonOk.Content".GetLocalizedString();
	private readonly string Cancel = "ButtonCancel.Content".GetLocalizedString();

	#region Window Input Dialog

	public async Task<string?> ShowTwoButtonDialogWithTextboxAsync(string title, string content, string rightButton = null!)
	{
		rightButton = string.IsNullOrWhiteSpace(rightButton) ? Ok : rightButton;

		var dialog = new ContentDialog()
		{
			Title = title,
			PrimaryButtonText = Cancel,
			SecondaryButtonText = rightButton,
			DefaultButton = ContentDialogButton.Primary,
			XamlRoot = App.MainWindow.Content.XamlRoot
		};

		var textBox = new TextBox();

		dialog.Content = new StackPanel
		{
			Width = 300,
			Height = 60,
			Spacing = 12,
			Children =
			{
				new TextBlock { Text = content },
				textBox
			}
		};

		var result = await dialog.ShowAsync();

		if (result == ContentDialogResult.Primary)
		{
			return null;
		}
		else if (result == ContentDialogResult.Secondary)
		{
			return textBox.Text.Trim();
		}
		else
		{
			return null;
		}
	}

	public async Task<string?> ShowTwoButtonDialogWithRichEditboxAsync(string title, string content, string rightButton = null!)
	{
		rightButton = string.IsNullOrWhiteSpace(rightButton) ? Ok : rightButton;

		var dialog = new ContentDialog()
		{
			Title = title,
			PrimaryButtonText = Cancel,
			SecondaryButtonText = rightButton,
			DefaultButton = ContentDialogButton.Primary,
			XamlRoot = App.MainWindow.Content.XamlRoot
		};

		var richEditBox = new RichEditBox()
		{
			Width = 400,
			Height = 150,
			TextWrapping = TextWrapping.Wrap,
			AcceptsReturn = true
		};

		dialog.Content = new StackPanel
		{
			Spacing = 12,
			Children =
			{
				new TextBlock { Text = content },
				richEditBox
			}
		};

		var result = await dialog.ShowAsync();

		if (result == ContentDialogResult.Primary)
		{
			return null;
		}
		else if (result == ContentDialogResult.Secondary)
		{
			richEditBox.Document.GetText(TextGetOptions.None, out string text);
			return text.Trim();
		}
		else
		{
			return null;
		}
	}

	#endregion Window Input Dialog

	#region Window Dialog

	public async Task ShowOneButtonDialogAsync(string title, string content)
	{
		var dialog = new ContentDialog()
		{
			Title = title,
			Content = content,
			PrimaryButtonText = Ok,
			DefaultButton = ContentDialogButton.Primary,
			XamlRoot = App.MainWindow.Content.XamlRoot
		};
		await dialog.ShowAsync();
	}

	public async Task<WidgetDialogResult> ShowTwoButtonDialogAsync(string title, string content, string leftButton = null!, string rightButton = null!)
	{
		leftButton = string.IsNullOrWhiteSpace(leftButton) ? Ok : leftButton;
		rightButton = string.IsNullOrWhiteSpace(rightButton) ? Cancel : rightButton;

		var dialog = new ContentDialog()
		{
			Title = title,
			Content = content,
			PrimaryButtonText = leftButton,
			SecondaryButtonText = rightButton,
			XamlRoot = App.MainWindow.Content.XamlRoot
		};
		var result = await dialog.ShowAsync();

		if (result == ContentDialogResult.Primary)
		{
			return WidgetDialogResult.Left;
		}
		else if (result == ContentDialogResult.Secondary)
		{
			return WidgetDialogResult.Right;
		}
		else
		{
			return WidgetDialogResult.Unknown;
		}
	}

	public async Task<WidgetDialogResult> ShowThreeButtonDialogAsync(string title, string content, string leftButton = null!, string centerButton = null!, string rightButton = null!)
	{
		if (string.IsNullOrWhiteSpace(centerButton))
		{
			return await ShowTwoButtonDialogAsync(title, content, leftButton, rightButton);
		}

		leftButton = string.IsNullOrWhiteSpace(leftButton) ? Ok : leftButton;
		rightButton = string.IsNullOrWhiteSpace(rightButton) ? Cancel : rightButton;

		var dialog = new ContentDialog()
		{
			Title = title,
			Content = content,
			PrimaryButtonText = leftButton,
			SecondaryButtonText = centerButton,
			CloseButtonText = rightButton,
			XamlRoot = App.MainWindow.Content.XamlRoot
		};
		var result = await dialog.ShowAsync();

		if (result == ContentDialogResult.Primary)
		{
			return WidgetDialogResult.Left;
		}
		else if (result == ContentDialogResult.Secondary)
		{
			return WidgetDialogResult.Right;
		}
		else if (result == ContentDialogResult.None)
		{
			return WidgetDialogResult.Right;
		}
		else
		{
			return WidgetDialogResult.Unknown;
		}
	}

	#endregion Window Dialog

	#region Full Screen Dialog

	public async Task ShowFullScreenOneButtonDialogAsync(string title, string content)
	{
		var dialog = new WindowedContentDialog()
		{
			WindowTitle = title,
			Title = title,
			Content = content,
			OwnerWindow = null,
			PrimaryButtonText = Ok,
			IsTitleBarVisible = false
		};
		await dialog.ShowAsync();
	}

	public async Task<WidgetDialogResult> ShowFullScreenTwoButtonDialogAsync(string title, string content, string leftButton = null!, string rightButton = null!)
	{
		leftButton = string.IsNullOrWhiteSpace(leftButton) ? Ok : leftButton;
		rightButton = string.IsNullOrWhiteSpace(rightButton) ? Cancel : rightButton;

		var dialog = new WindowedContentDialog()
		{
			WindowTitle = title,
			Title = title,
			Content = content,
			OwnerWindow = null,
			PrimaryButtonText = leftButton,
			SecondaryButtonText = rightButton,
			IsTitleBarVisible = false
		};
		var result = await dialog.ShowAsync();

		if (result == ContentDialogResult.Primary)
		{
			return WidgetDialogResult.Left;
		}
		else if (result == ContentDialogResult.Secondary)
		{
			return WidgetDialogResult.Right;
		}
		else
		{
			return WidgetDialogResult.Unknown;
		}
	}

	public async Task<WidgetDialogResult> ShowFullScreenThreeButtonDialogAsync(string title, string content, string leftButton = null!, string centerButton = null!, string rightButton = null!)
	{
		if (string.IsNullOrWhiteSpace(centerButton))
		{
			return await ShowFullScreenTwoButtonDialogAsync(title, content, leftButton, rightButton);
		}

		leftButton = string.IsNullOrWhiteSpace(leftButton) ? Ok : leftButton;
		rightButton = string.IsNullOrWhiteSpace(rightButton) ? Cancel : rightButton;

		var dialog = new WindowedContentDialog()
		{
			WindowTitle = title,
			Title = title,
			Content = content,
			OwnerWindow = null,
			PrimaryButtonText = leftButton,
			SecondaryButtonText = centerButton,
			CloseButtonText = rightButton,
			IsTitleBarVisible = false
		};
		var result = await dialog.ShowAsync();

		if (result == ContentDialogResult.Primary)
		{
			return WidgetDialogResult.Left;
		}
		else if (result == ContentDialogResult.Secondary)
		{
			return WidgetDialogResult.Right;
		}
		else if (result == ContentDialogResult.None)
		{
			return WidgetDialogResult.Right;
		}
		else
		{
			return WidgetDialogResult.Unknown;
		}
	}

	#endregion Full Screen Dialog
}

public enum WidgetDialogResult
{
	Left,
	Center,
	Right,
	Unknown
}
