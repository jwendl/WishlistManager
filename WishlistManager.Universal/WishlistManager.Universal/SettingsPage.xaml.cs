using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WishlistManager.Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        private ApplicationDataContainer roamingSettings { get; set; }

        public SettingsPage()
        {
            this.InitializeComponent();

            roamingSettings = ApplicationData.Current.RoamingSettings;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var amazonKey = roamingSettings.Values["AmazonKey"];
            if (amazonKey != null)
            {
                AmazonKey.Text = amazonKey.ToString();
            }

            var amazonSecret = roamingSettings.Values["AmazonSecret"];
            if (amazonSecret != null)
            {
                AmazonSecret.Text = amazonSecret.ToString();
            }

            base.OnNavigatedTo(e);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            roamingSettings.Values["AmazonKey"] = AmazonKey.Text;
            roamingSettings.Values["AmazonSecret"] = AmazonSecret.Text;
            Frame.Navigate(typeof(MainPage));
        }
    }
}
