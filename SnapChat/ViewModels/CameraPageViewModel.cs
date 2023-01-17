
using Windows.Media.Capture;
using Windows.UI.Xaml.Controls;
using SnapChat.Helpers;
using SnapDotNet.Data;

namespace SnapChat.ViewModels
{
	public sealed class CameraPageViewModel
		: BaseViewModel
	{
		private MediaCapture _mcapSource;
		public MediaCapture MediaCaptureSource //databind viewfinder to this property
		{
			get { return _mcapSource; }
			set { _mcapSource = value; }
		}
		public CameraPageViewModel()
		{
			
		}
		//public CameraPageViewModel(MediaCapture mediaCaptureToBind)
		//{
		//	_mcapSource = mediaCaptureToBind;
		//}
	}
}
