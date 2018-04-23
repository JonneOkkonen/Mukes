using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Mukes.Core;
using Android.Content;
using Android.Preferences;
using Java.Util;
using Android.Content.Res;

namespace Mukes.Droid
{
    [Activity(Label = "Mukes", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MenuListActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        ListView _menuList;
        TextView _restaurantName;
        private string language;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Content View
            SetContentView(Resource.Layout.MenuListView);

            // Resources
            _restaurantName = FindViewById<TextView>(Resource.Id.restaurantName);
            var refreshButton = FindViewById<ImageButton>(Resource.Id.refresh);
            var settingsButton = FindViewById<ImageButton>(Resource.Id.settings);
            _menuList = FindViewById<ListView>(Resource.Id.menuList);

            // Set Language
            language = SetLanguage();

            // Load Menu to ListView
            LoadMenu();

            // Settings Button
            settingsButton.Click += (sender, ea) =>
            {
                // Go to settings
                StartActivity(new Intent(ApplicationContext, typeof(SettingsActivity)));
            };

            // Refresh Button
            refreshButton.Click += (sender, ea) =>
            {
                // Load Menu to ListView
                LoadMenu();
            };
        }

        // Load Menu to ListView
        private void LoadMenu()
        {
            // Read selectedRestaurant name and URL from SharedPreferences
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            var name = prefs.GetString("selectedRestaurantName", "noValue");
            var url = prefs.GetString("selectedRestaurantURL", "noValue");

            // Set Restaurant Name
            if(name == "noValue"){
                _restaurantName.Text = GetString(Resource.String.selectRestaurant);
            }else{
                _restaurantName.Text = name;
            }

            RSSFeed.List.Clear(); // Clear RSSFeed List
            // Fetch RSS Feed
            switch (RSSFeed.Fetch(url, language))
            {
                case "FetchSuccessfull":
                    // Add MenuListAdapter to menuList
                    MenuListAdapter customAdapter = new MenuListAdapter(this, RSSFeed.List);
                    _menuList.Adapter = customAdapter;
                    break;
                case "NetworkError":
                    System.Diagnostics.Debug.WriteLine("RSSFeed Fetch: NetworkError");
                    Notifications.CreateAlert(this, GetString(Resource.String.networkError)).Show();
                    break;
                case "noURL":
                    Notifications.CreateAlert(this, GetString(Resource.String.noRestaurantSelected)).Show();
                    break;
            }
        }

        // Set Language
        private string SetLanguage()
        {
            // Load Language from SharedPreferences
            var language = PreferenceManager.GetDefaultSharedPreferences(ApplicationContext).GetString("selectedLanguage", "en");
            var locale = new Locale(language);
            Locale.Default = locale;
            Configuration config = new Configuration();
            config.Locale = locale;

            // Update Configuration
            if (Android.OS.Build.VERSION.SdkInt >= (Android.OS.BuildVersionCodes)25)
            {
                this.CreateConfigurationContext(config);
            }
            else
            {
#pragma warning disable 0618
                //UpdateConfiguration deprecated in API 25
                this.Resources.UpdateConfiguration(config, this.Resources.DisplayMetrics);
#pragma warning restore 0618
            }
            return language;
        }

        // When coming back from Settings LoadMenu again
        protected override void OnResume()
        {
            base.OnResume();
            language = SetLanguage();
            LoadMenu();
        }
    }
}

