using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SnapChat.Converters
{
	public sealed class NullToVisibilityConverter
		: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (IsInverted)
				return (value == null) ? Visibility.Visible : Visibility.Collapsed;

			return (value != null) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}

		public bool IsInverted { get; set; }
	}
}