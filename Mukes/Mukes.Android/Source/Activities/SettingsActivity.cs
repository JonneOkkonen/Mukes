using System;
using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Mukes.Core;

namespace Mukes.Droid
{
    [Activity(Label = "Settings", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SettingsActivity : AppCompatActivity
    {
        private List<string> restaurantList = new List<string>();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Content View
            SetContentView(Resource.Layout.Settings);

            // Toolbar Setup
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // Resources
            var restaurantText = FindViewById<TextView>(Resource.Id.selectRestaurant);
            var restaurants = FindViewById<Spinner>(Resource.Id.restaurants);

            // Language Translations
            restaurantText.Text = "Valitse ravintola";
            restaurantList.Add("Valitse ravintola");

            // Add restaurant to restaurantList from RSSFeedList
            foreach (RestaurantsStructure item in Lists.RSSFeedList)
            {
                restaurantList.Add(item.Name);
            }

            // Add restaurantList to dropDownMenu
            ArrayAdapter<String> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, restaurantList);
            restaurants.Adapter = adapter;
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