using System;
using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Mukes.Core;
using Android.Content;

namespace Mukes.Droid
{
    [Activity(Label = "Mukes", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MenuListActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Content View
            SetContentView(Resource.Layout.MenuListView);

            // Resources
            var restaurantName = FindViewById<TextView>(Resource.Id.restaurantName);
            var refreshButton = FindViewById<ImageButton>(Resource.Id.refresh);
            var settingsButton = FindViewById<ImageButton>(Resource.Id.settings);
            var menuList = FindViewById<ListView>(Resource.Id.menuList);
            
            // Add Data
            List<string> menu = new List<string>();

            // Fetch RSS Feed
            RSSFeed.Fetch();

            // Fill menuList
            // CHANGE TO USE RSSFEED.List AFTER CUSTOM LIST ITEM IS CREATED
            foreach(MenuStructure item in RSSFeed.List)
            {
                menu.Add($"{item.Title} Aamupala:{item.Breakfast} Lounas:{item.Lunch} Päivällinen:{item.Dinner} Iltapala:{item.EveningSnack}");
            }

            // MenuAdapter
            ArrayAdapter<string> menuAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, menu);

            // Add Adapter to menuList
            menuList.Adapter = menuAdapter;

            // Settings Button
            settingsButton.Click += (sender, ea) =>
            {
                // Go to settings
                StartActivity(new Intent(ApplicationContext, typeof(SettingsActivity)));
            };

            // Refresh Button
            refreshButton.Click += (sender, ea) =>
            {
                // TODO: Refresh Here
            };
        }
    }
}

