using System.Collections.Generic;
using Android.OS;
using Android.Preferences;
using Mukes.Core;

namespace Mukes.Droid
{
    public class SettingsFragment : PreferenceFragment
    {
        public static ListPreference restaurantList;
        public static ListPreference languageList;
        public override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Load Preference View from Resources
            AddPreferencesFromResource(Resource.Layout.SettingsFragment);

            // Preference Items
            restaurantList = (ListPreference)FindPreference("restaurantList");
            languageList = (ListPreference)FindPreference("languageList");
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
            restaurantList.SetEntries(names.ToArray()); // Restaurant Names
            restaurantList.SetEntryValues(urls.ToArray()); // Restaurant URL's
            restaurantList.DialogTitle = "Select Restaurant";

            // Language List
            languageList.Title = "Language";
            languageList.SetEntries(Lists.Language.ToArray());
            languageList.SetEntryValues(Lists.Language.ToArray());
            languageList.DialogTitle = "Select Language";

            // Version
            currentVersion.Title = "Version";
            currentVersion.Summary = "1.0";
        }
    }
}