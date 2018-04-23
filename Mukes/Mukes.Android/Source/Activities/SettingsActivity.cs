using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace Mukes.Droid
{
    [Activity(Label = "SettingsActivity", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SettingsActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
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
                Finish();
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}