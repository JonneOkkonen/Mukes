using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace Mukes.Droid
{
    public class Language
    {
        // Set Language
        public static string Set(Context context, string lang = null)
        {
            // Load Language from SharedPreferences
            var language = lang ?? PreferenceManager.GetDefaultSharedPreferences(context).GetString("selectedLanguage", "en");
            var locale = new Locale(language);
            Locale.Default = locale;
            Configuration config = new Configuration();
            config.Locale = locale;

            // Update Configuration
            if (Android.OS.Build.VERSION.SdkInt >= (Android.OS.BuildVersionCodes)25)
            {
                context.CreateConfigurationContext(config);
            }
            else
            {
#pragma warning disable 0618
                //UpdateConfiguration deprecated in API 25
                context.Resources.UpdateConfiguration(config, context.Resources.DisplayMetrics);
#pragma warning restore 0618
            }
            return language;
        }
    }
}