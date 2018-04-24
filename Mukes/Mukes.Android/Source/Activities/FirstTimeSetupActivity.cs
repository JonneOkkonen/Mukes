using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Mukes.Droid
{
    [Activity(Label = "Mukes", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class FirstTimeSetupActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set ContentView
            SetContentView(Resource.Layout.FirstTimeSetup);

            // Resources
            var title = FindViewById<TextView>(Resource.Id.title);
            var selectLanguageTitle = FindViewById<TextView>(Resource.Id.selectLanguage);
            var finnish = FindViewById<ImageButton>(Resource.Id.finnish);
            var svenska = FindViewById<ImageButton>(Resource.Id.svenska);
            var english = FindViewById<ImageButton>(Resource.Id.english);
            var selectRestaurantTitle = FindViewById<TextView>(Resource.Id.selectRestaurantTitle);
            var selectRestaurant = FindViewById<Spinner>(Resource.Id.selectRestaurant);
            var saveSettings = FindViewById<Button>(Resource.Id.saveSettings);


        }
    }
}