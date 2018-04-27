using System.Collections.Generic;
using Android.Content;
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
            var developer = FindPreference("developer");
            var feedback = FindPreference("feedback");

            // List for Restaurant names and URLs
            List<string> names = new List<string>();
            List<string> urls = new List<string>();

            // Add Restaurant names and url's to their list's
            foreach (RestaurantsStructure item in Lists.RSSFeed){
                names.Add(item.Name);
                urls.Add(item.RSSFeedURL);
            }

            // Set values to PreferenceItems
            // Restaurant List
            restaurantList.Title = GetString(Resource.String.restaurantTitle);
            restaurantList.SetEntries(names.ToArray()); // Restaurant Names
            restaurantList.SetEntryValues(urls.ToArray()); // Restaurant URL's
            restaurantList.DialogTitle = GetString(Resource.String.selectRestaurant);

            // Language List
            languageList.Title = GetString(Resource.String.languageTitle);
            languageList.SetEntries(Lists.Language.ToArray());
            languageList.SetEntryValues(Lists.Language.ToArray());
            languageList.DialogTitle = GetString(Resource.String.selectLanguage);

            // Load Values from SharedPreferences after FirstTimeSetup

            // RestaurantList
            if (SettingsActivity.Name != "noValue")
            {
                restaurantList.Summary = SettingsActivity.Name;
            }
            restaurantList.PreferenceChange += (sender, ea) => {
                restaurantList.Summary = "%s";
            };

            // LanguageList
            if (SettingsActivity.Language != "noValue") {
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
            currentVersion.Summary = SettingsActivity.Version;

            // Developer
            developer.Title = GetString(Resource.String.developer);
            developer.Summary = "Jonne Okkonen";

            // Feedback
            feedback.Title = GetString(Resource.String.feedback);
            feedback.Summary = GetString(Resource.String.feedbackMsg);
            feedback.PreferenceClick += (sender, ea) =>
            {
                // Open Google Form
                OpenPage("https://goo.gl/forms/igh5hHvLwroUl3o52");
            };
        }

        // Open WebPage
        private void OpenPage(string url)
        {
            var uri = Android.Net.Uri.Parse(url);
            var intent = new Intent(Intent.ActionView, uri);
            this.StartActivity(intent);
        }
    }
}