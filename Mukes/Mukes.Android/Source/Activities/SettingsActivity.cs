using System;
using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Preferences;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Mukes.Core;

namespace Mukes.Droid
{
    [Activity(Label = "Settings", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SettingsActivity : PreferenceActivity
    {
        private ListPreference restaurantList;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Load Preference View from Resources
            AddPreferencesFromResource(Resource.Layout.Settings);

            // Preference Items
            restaurantList = (ListPreference)FindPreference("restaurantList");
            var currentVersion = FindPreference("currentVersion");

            // List for Restaurant names and URLs
            List<string> names = new List<string>();
            List<string> urls = new List<string>();

            // Add Restaurant names and url's to their list's
            foreach (RestaurantsStructure item in Lists.RSSFeedList){
                names.Add(item.Name);
                urls.Add(item.RSSFeedURL);
            }

            // Set values to PreferenceItems
            // Restaurant List
            restaurantList.Title = "Restaurant";
            restaurantList.Summary = "Select Restaurant"; // Description
            restaurantList.SetEntries(names.ToArray()); // Restaurant Names
            restaurantList.SetEntryValues(urls.ToArray()); // Restaurant URL's
            restaurantList.DialogTitle = "Select Restaurant";
            restaurantList.PreferenceChange += RestaurantList_PreferenceChange; // Preference Changed Action

            // Version
            currentVersion.Title = "Version";
            currentVersion.Summary = "1.0";
        }

        // Restaurant List Selection Action
        private void RestaurantList_PreferenceChange(object sender, Preference.PreferenceChangeEventArgs e)
        {
            restaurantList.Summary = restaurantList.Entry;
        }

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