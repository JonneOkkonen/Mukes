using System;
using System.Collections.Generic;
using System.Text;

namespace Mukes.Core
{
    public class Keywords
    {
        public static List<string> Viikonpaiva = new List<string>(new string[] {
            "Maanantai",
            "Tiistai",
            "Keskiviikko",
            "Torstai",
            "Perjantai",
            "Lauantai",
            "Sunnuntai"
        });

        public static List<string> DayOfTheWeek = new List<string>(new string[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        });

        public static List<string> DateFormats = new List<string>(new string[]
        {
            @"(?<day>\d{2}).(?<month>\d{2}).(?<year>\d{4})", // 00.00.0000
            @"(?<day>\d{2}).(?<month>\d{1}).(?<year>\d{4})", // 00.0.0000
            @"(?<day>\d{1}).(?<month>\d{2}).(?<year>\d{4})", // 0.00.0000
            @"(?<day>\d{1}).(?<month>\d{1}).(?<year>\d{4})" // 0.0.0000

        });

        public enum Meals { Breakfast, Lunch, Dinner, EveningSnack };

        public static List<string> MealsFI = new List<string>(new string[]
        {
            "Aamiainen",
            "Lounas",
            "Päivällinen",
            "Iltapala"
        });

        public static List<string> MealsEN = new List<string>(new string[]
        {
            "Breakfast",
            "Lunch",
            "Dinner",
            "Evening snack"
        });
    }
}
