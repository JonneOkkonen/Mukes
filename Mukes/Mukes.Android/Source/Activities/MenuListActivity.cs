using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Mukes.Core;
using Android.Content;
using Android.Preferences;

namespace Mukes.Droid
{
    [Activity(Label = "Mukes", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MenuListActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        ListView _menuList;
        TextView _restaurantName;
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
                _restaurantName.Text = "Select restaurant";
            }else{
                _restaurantName.Text = name;
            }

            RSSFeed.List.Clear(); // Clear RSSFeed List
            // Fetch RSS Feed
            switch (RSSFeed.Fetch(url))
            {
                case "FetchSuccessfull":
                    // Add MenuListAdapter to menuList
                    MenuListAdapter customAdapter = new MenuListAdapter(this, RSSFeed.List);
                    _menuList.Adapter = customAdapter;
                    break;
                case "NetworkError":
                    System.Diagnostics.Debug.WriteLine("RSSFeed Fetch: NetworkError");
                    Notifications.CreateAlert(this, "NetworkError").Show();
                    break;
                case "noURL":
                    Notifications.CreateAlert(this, "No Restaurant Selected.\n Go to the Settings and Select your restaurant.").Show();
                    break;
            }
        }
    }
}

