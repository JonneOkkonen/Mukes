using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Mukes.Core;
using Android.Content;

namespace Mukes.Droid
{
    [Activity(Label = "Mukes", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MenuListActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Content View
            SetContentView(Resource.Layout.MenuListView);

            // Resources
            var restaurantName = FindViewById<TextView>(Resource.Id.restaurantName);
            var refreshButton = FindViewById<ImageButton>(Resource.Id.refresh);
            var settingsButton = FindViewById<ImageButton>(Resource.Id.settings);
            var menuList = FindViewById<ListView>(Resource.Id.menuList);

            // Restaurant Name
            restaurantName.Text = "Sahara, Helsinki";

            // Fetch RSS Feed
            switch(RSSFeed.Fetch())
            {
                case "FetchSuccessfull":
                    // Add MenuListAdapter to menuList
                    MenuListAdapter customAdapter = new MenuListAdapter(this, RSSFeed.List);
                    menuList.Adapter = customAdapter;
                    break;
                case "NetworkError":
                    System.Diagnostics.Debug.WriteLine("RSSFeed Fetch: NetworkError");
                    Notifications.CreateAlert(this, "NetworkError").Show();
                    break;
            }

            // Settings Button
            settingsButton.Click += (sender, ea) =>
            {
                // Go to settings
                StartActivity(new Intent(ApplicationContext, typeof(SettingsActivity)));
            };

            // Refresh Button
            refreshButton.Click += (sender, ea) =>
            {
                // TODO: Refresh Here
            };
        }
    }
}

