using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SnapChat.Common;
using SnapChat.Helpers;
using SnapChat.ViewModels;
using SnapDotNet.Data;

namespace SnapChat.Pages
{
	public sealed partial class CameraPage
	{
		private CameraControlHelper camch = new CameraControlHelper();
		public CameraPage()
		{

			InitializeComponent();
			ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseCoreWindow);
			DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;

			NavigationHelper = new NavigationHelper(this);
			NavigationHelper.LoadState += NavigationHelper_LoadState;
			NavigationHelper.SaveState += NavigationHelper_SaveState;

			DataContext = new CameraPageViewModel();

			//StartInitializingAsync(); -> going out for a bit, audioDevice throwing exceptions, need to fix
		}

		private async Task StartInitializingAsync()
		{
			CameraTriggerButton.IsTapEnabled = false;

			await camch.InitializeCameraAsync();
			await camch.StartPreviewAsync();

			ViewModel.MediaCaptureSource = camch.MediaCapture; //must be done post initilization :( == messy.
			CapturePreview.Source = ViewModel.MediaCaptureSource;

			CameraTriggerButton.IsTapEnabled = true;
		}
		private void CaptureButton_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
		{

		}


		/// <summary>
		/// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
		/// </summary>
		public NavigationHelper NavigationHelper { get; private set; }

		/// <summary>
		/// Gets the view model of this page.
		/// </summary>
		public CameraPageViewModel ViewModel
		{
			get { return DataContext as CameraPageViewModel; }
		}

		/// <summary>
		/// Populates the page with content passed during navigation.  Any saved state is also
		/// provided when recreating a page from a prior session.
		/// </summary>
		/// <param name="sender">
		/// The source of the event; typically <see cref="NavigationHelper"/>
		/// </param>
		/// <param name="e">Event data that provides both the navigation parameter passed to
		/// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
		/// a dictionary of state preserved by this page during an earlier
		/// session.  The state will be null the first time a page is visited.</param>
		private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
		{
			ViewModel.Account = e.NavigationParameter as Account;
		}

		/// <summary>
		/// Preserves state associated with this page in case the application is suspended or the
		/// page is discarded from the navigation cache.  Values must conform to the serialization
		/// requirements of <see cref="SuspensionManager.SessionState"/>.
		/// </summary>
		/// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
		/// <param name="e">Event data that provides an empty dictionary to be populated with
		/// serializable state.</param>
		private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
		{
		}

		#region NavigationHelper registration

		/// <summary>
		/// The methods provided in this section are simply used to allow
		/// NavigationHelper to respond to the page's navigation methods.
		/// <para>
		/// Page specific logic should be placed in event handlers for the  
		/// <see cref="NavigationHelper.LoadState"/>
		/// and <see cref="NavigationHelper.SaveState"/>.
		/// The navigation parameter is available in the LoadState method 
		/// in addition to page state preserved during an earlier session.
		/// </para>
		/// </summary>
		/// <param name="e">Provides data for navigation methods and event
		/// handlers that cannot cancel the navigation request.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			NavigationHelper.OnNavigatedTo(e);
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			NavigationHelper.OnNavigatedFrom(e);
		}

		#endregion
	}
}
