using Windows.UI.Xaml.Controls;

namespace HostApp
{
	public sealed partial class MainPage : Page
	{
		private ContentManager _mgr;

		public MainPage()
		{
			this.InitializeComponent();

			this.Loaded += (snd, evt) => Launch();
		}

		private void Launch()
		{
			_mgr = new ContentManager();
		}
	}
}
