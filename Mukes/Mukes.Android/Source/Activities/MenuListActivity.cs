using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

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

            // MenuList
            List<string> menu = new List<string>();
            
            // Add Data
            heading.Text = "Ruokalista";
            menu.Add("Maanantai");
            menu.Add("Tiistai");

            // MenuAdapter
            ArrayAdapter<string> menuAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, menu);

            // Add Adapter to menuList
            menuList.Adapter = menuAdapter;

        }
    }
}

