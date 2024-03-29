﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Preferences;
using Android.Support.V7.App;
using Android.Views;

namespace Mukes.Droid
{
    [Activity(Label = "SettingsActivity", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SettingsActivity : AppCompatActivity
    {
        public static string Name;
        public static string Language;
        public static string Version;
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

            // Load Data from SharedPreferences
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            Name = prefs.GetString("selectedRestaurantName", "noValue");
            Language = prefs.GetString("selectedLanguage", "noValue");

            // Get Current Version
            Version = GetVersion();

            // Load Fragment
            var fragment = new SettingsFragment();
            var fragmentManager = FragmentManager.BeginTransaction();
            fragmentManager.Add(Resource.Id.settingsFragment, fragment);
            fragmentManager.Commit();
        }

        // Toolbar Back-button
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }
            return base.OnOptionsItemSelected(item);
        }

        // Save Changes when Finish
        public override void Finish()
        {
            base.Finish();

            // Check If restaurantList Entry is null
            if (SettingsFragment.restaurantList.Entry != null)
            {
                // Save selectedRestaurant Name and URL to SharedPreferences
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString("selectedRestaurantName", SettingsFragment.restaurantList.Entry);
                editor.PutString("selectedRestaurantURL", SettingsFragment.restaurantList.Value);
                editor.Apply();
            }

            // Check If languageList Entry is null
            if(SettingsFragment.languageList.Entry != null)
            {
                // Save selectedLanguage to SharedPreferences
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = prefs.Edit();
                switch (SettingsFragment.languageList.Value)
                {
                    case "Suomi":
                        editor.PutString("selectedLanguage", "fi");
                        break;
                    case "English":
                        editor.PutString("selectedLanguage", "en");
                        break;
                    case "Svenska":
                        editor.PutString("selectedLanguage", "sv");
                        break;
                }
                editor.Apply();
            }
        }

        // Get Current Version
        public string GetVersion()
        {
            var context = global::Android.App.Application.Context;

            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);

            return info.VersionName;
        }
    }
}