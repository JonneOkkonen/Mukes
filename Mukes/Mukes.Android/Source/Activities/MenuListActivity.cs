using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Mukes.Core;
using Android.Content;
using Android.Util;
using AndroidX.AppCompat.App;
using Android.App;
using Mukes.Android;

namespace Mukes.Droid
{
    [Activity(Label = "Mukes", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MenuListActivity : AppCompatActivity
    {

        ListView _menuList;
        TextView _restaurantName;
        private string language;
        private const string TAG = "MenuListActivity";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Check If FirstTimeSetups has been done
            if(SetupChecker() == "RunSetup") {

                // Go to FirstTimeSetup
                StartActivity(new Intent(ApplicationContext, typeof(FirstTimeSetupActivity)));
            }

            // Content View
            SetContentView(Resource.Layout.MenuListView);

            // Resources
            _restaurantName = FindViewById<TextView>(Resource.Id.restaurantName);
            var refreshButton = FindViewById<ImageButton>(Resource.Id.refresh);
            var settingsButton = FindViewById<ImageButton>(Resource.Id.settings);
            _menuList = FindViewById<ListView>(Resource.Id.menuList);

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
            string prefName = $"{PackageName}_preferences";
            ISharedPreferences prefs = GetSharedPreferences(prefName, FileCreationMode.Private);
            var name = prefs.GetString("selectedRestaurantName", "noValue");
            var url = prefs.GetString("selectedRestaurantURL", "noValue");
            language = prefs.GetString("selectedLanguage", "noValue");

            // Set Restaurant Name
            if (name == "noValue"){
                _restaurantName.Text = GetString(Resource.String.selectRestaurant);
            } else{
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
                    Log.Debug(TAG, "RSSFeed Fetch: NetworkError");
                    Notifications.CreateAlert(this, GetString(Resource.String.networkError)).Show();
                    break;
                case "Error":
                    Log.Debug(TAG, "RSSFeed Fetch: Error");
                    Notifications.CreateAlert(this, GetString(Resource.String.networkError)).Show();
                    break;
                case "noURL":
                    Log.Debug(TAG, "RSSFeed Fetch: No urls selected");
                    Notifications.CreateAlert(this, GetString(Resource.String.noRestaurantSelected)).Show();
                    break;
            }
        }

        // When coming back from Settings LoadMenu again
        protected override void OnResume()
        {
            base.OnResume();
            LoadMenu();
        }

        // Check If FirstTimeSetup has been done
        private string SetupChecker()
        {
            string prefName = $"{PackageName}_preferences";
            ISharedPreferences prefs = GetSharedPreferences(prefName, FileCreationMode.Private);
            var name = prefs.GetString("selectedRestaurantName", "noValue");
            var url = prefs.GetString("selectedRestaurantURL", "noValue");
            language = prefs.GetString("selectedLanguage", "noValue");

            if(name == "noValue" && url == "noValue" && language == "noValue"){
                return "RunSetup";
            } else{
                return "Continue";
            }
        }
    }
}

