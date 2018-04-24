using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Mukes.Core;

namespace Mukes.Droid
{
    [Activity(Label = "Mukes", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class FirstTimeSetupActivity : Activity
    {
        private string SelectedLanguage;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set ContentView
            SetContentView(Resource.Layout.FirstTimeSetup);

            // Get Language that phone uses
            string lang = Resources.Configuration.Locale.ToString();

            // Set Language that phone uses
            Language.Set(this, lang);
            SelectedLanguage = lang;

            // Resources
            var title = FindViewById<TextView>(Resource.Id.title);
            var selectLanguageTitle = FindViewById<TextView>(Resource.Id.selectLanguage);
            var finnish = FindViewById<ImageButton>(Resource.Id.finnish);
            var svenska = FindViewById<ImageButton>(Resource.Id.svenska);
            var english = FindViewById<ImageButton>(Resource.Id.english);
            var selectRestaurantTitle = FindViewById<TextView>(Resource.Id.selectRestaurantTitle);
            var selectRestaurant = FindViewById<Spinner>(Resource.Id.selectRestaurant);
            var saveSettings = FindViewById<Button>(Resource.Id.saveSettings);

            // Select Language that phone uses
            switch(lang)
            {
                case "fi":
                    finnish.SetImageResource(Resource.Drawable.finnish_flag_selected);
                    break;
                case "sv":
                    svenska.SetImageResource(Resource.Drawable.sweden_flag_selected);
                    break;
                case "en":
                    english.SetImageResource(Resource.Drawable.united_kingdom_flag_selected);
                    break;
            }

            // Change Image to Selected when user clicks flag
            finnish.Click += (sender, ea) =>
            {
                finnish.SetImageResource(Resource.Drawable.finnish_flag_selected);
                svenska.SetImageResource(Resource.Drawable.sweden_flag);
                english.SetImageResource(Resource.Drawable.united_kingdom_flag);
                SelectedLanguage = "fi";
            };
            svenska.Click += (sender, ea) =>
            {
                finnish.SetImageResource(Resource.Drawable.finnish_flag);
                svenska.SetImageResource(Resource.Drawable.sweden_flag_selected);
                english.SetImageResource(Resource.Drawable.united_kingdom_flag);
                SelectedLanguage = "sv";
            };
            english.Click += (sender, ea) =>
            {
                finnish.SetImageResource(Resource.Drawable.finnish_flag);
                svenska.SetImageResource(Resource.Drawable.sweden_flag);
                english.SetImageResource(Resource.Drawable.united_kingdom_flag_selected);
                SelectedLanguage = "en";
            };

            // Load Restaurants to List
            List<string> restaurants = new List<string>();
            foreach (RestaurantsStructure item in Lists.RSSFeedList){
                restaurants.Add(item.Name);
            }

            // Language Translations
            title.Text = GetString(Resource.String.firstTimeSetupTitle);
            selectLanguageTitle.Text = GetString(Resource.String.selectLanguage);
            selectRestaurantTitle.Text = GetString(Resource.String.selectRestaurant);
            saveSettings.Text = GetString(Resource.String.saveChanges);

            // Spinner Adapter
            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, restaurants);

            // Add adapter to Spinner
            selectRestaurant.Adapter = adapter;

            // Save Changes
            saveSettings.Click += (sender, ea) =>
            {
                // Get restaurant Name and URL
                string restaurantName = selectRestaurant.SelectedItem.ToString();
                string restaurantURL = Lists.RSSFeedList[Lists.RSSFeedList.FindIndex(x => x.Name == restaurantName)].RSSFeedURL;

                // Save data to SharedPreferences
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString("selectedLanguage", SelectedLanguage);
                editor.PutString("selectedRestaurantName", restaurantName);
                editor.PutString("selectedRestaurantURL", restaurantURL);
                editor.Apply();

                // Go to MenuListActivity
                StartActivity(new Intent(ApplicationContext, typeof(MenuListActivity)));
            };
        }
    }
}