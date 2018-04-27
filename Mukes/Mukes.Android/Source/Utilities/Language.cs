using Android.Content;
using Android.Content.Res;
using Android.Preferences;
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

            Configuration config = context.Resources.Configuration;

            Locale locale = new Locale(language);
            Locale.Default = locale;
            config.Locale = locale;

            //UpdateConfiguration deprecated in API 25
            context.Resources.UpdateConfiguration(config, context.Resources.DisplayMetrics);

            return language;
        }
    }
}