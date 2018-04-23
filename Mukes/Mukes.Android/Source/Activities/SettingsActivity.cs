using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

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

            // Load Fragment
            var fragment = new SettingsFragment();
            var fragmentManager = FragmentManager.BeginTransaction();
            fragmentManager.Add(Resource.Id.settingsFragment, fragment);
            fragmentManager.Commit();
        }
    }
}