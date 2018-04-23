using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Preferences;
using Android.Support.V7.App;
using Android.Views;

namespace Mukes.Droid
{
    [Activity(Label = "SettingsActivity", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SettingsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set View
            SetContentView(Resource.Layout.SettingsActivity);

            // Toolbar Setup
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetTitle(Resource.String.settingsTitle);

            // Load Fragment
            var fragment = new SettingsFragment();
            var fragmentManager = FragmentManager.BeginTransaction();
            fragmentManager.Add(Resource.Id.settingsFragment, fragment);
            fragmentManager.Commit();
        }

        // Back-button
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                // Save selectedRestaurant URL to SharedPreferences
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString("selectedLanguage", SettingsFragment.languageList.Value);
                editor.PutString("selectedRestaurantName", SettingsFragment.restaurantList.Entry);
                editor.PutString("selectedRestaurantURL", SettingsFragment.restaurantList.Value);
                editor.Apply();

                Finish();
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}