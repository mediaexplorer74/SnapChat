using SnapDotNet.Data;
using SnapDotNet.Utilities;

namespace SnapChat.ViewModels
{
	public class BaseViewModel
		: ObservableObject
	{
		public Account Account
		{
			get { return _account; }
			set { SetValue(ref _account, value); }
		}
		private Account _account;
	}
}