using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Mukes.Core;

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

            // Elements
            var heading = FindViewById<TextView>(Resource.Id.heading);
            var menuList = FindViewById<ListView>(Resource.Id.menuList);
            
            // Add Data
            heading.Text = "Ruokalista";
            List<string> menu = new List<string>();

            // Fetch RSS Feed
            RSSFeed.Fetch();

            // Fill menuList
            // CHANGE TO USE RSSFEED.List AFTER CUSTOM LIST ITEM IS CREATED
            foreach(MenuStructure item in RSSFeed.List)
            {
                menu.Add($"{item.Title} {item.Description}");
            }

            // MenuAdapter
            ArrayAdapter<string> menuAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, menu);

            // Add Adapter to menuList
            menuList.Adapter = menuAdapter;
        }
    }
}

