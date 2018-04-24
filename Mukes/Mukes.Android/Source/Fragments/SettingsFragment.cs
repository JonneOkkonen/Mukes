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
            restaurantList.Title = GetString(Resource.String.restaurantTitle);
            restaurantList.SetEntries(names.ToArray()); // Restaurant Names
            restaurantList.SetEntryValues(urls.ToArray()); // Restaurant URL's
            restaurantList.DialogTitle = GetString(Resource.String.selectRestaurant);
            if(SettingsActivity.Name != "noValue" && restaurantList.Summary == "%s") {
                restaurantList.Summary = SettingsActivity.Name;
            }
            restaurantList.PreferenceChange += (sender, ea) => {
                restaurantList.Summary = "%s";
            };

            // Language List
            languageList.Title = GetString(Resource.String.languageTitle);
            languageList.SetEntries(Lists.Language.ToArray());
            languageList.SetEntryValues(Lists.Language.ToArray());
            languageList.DialogTitle = GetString(Resource.String.selectLanguage);
            if (SettingsActivity.Language != "noValue" && languageList.Summary == "%s") {
                switch(SettingsActivity.Language)
                {
                    case "fi":
                        languageList.Summary = "Suomi";
                        break;
                    case "sv":
                        languageList.Summary = "Svenska";
                        break;
                    case "en":
                        languageList.Summary = "English";
                        break;
                }
            }
            languageList.PreferenceChange += (sender, ea) => {
                languageList.Summary = "%s";
            };

            // Version
            currentVersion.Title = GetString(Resource.String.versionTitle);
            currentVersion.Summary = "1.0";
        }
    }
}