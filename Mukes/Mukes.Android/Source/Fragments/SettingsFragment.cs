using System.Collections.Generic;
using Android.OS;
using Android.Preferences;
using Mukes.Core;

namespace Mukes.Droid
{
    public class SettingsFragment : PreferenceFragment
    {
        private ListPreference restaurantList;
        public override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Load Preference View from Resources
            AddPreferencesFromResource(Resource.Layout.SettingsFragment);

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
    }
}