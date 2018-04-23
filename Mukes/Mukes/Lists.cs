using System;
using System.Collections.Generic;
using System.Text;

namespace Mukes.Core
{
    public class Lists
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

        public static List<RestaurantsStructure> RSSFeedList = new List<RestaurantsStructure>(new RestaurantsStructure[]
        {
            new RestaurantsStructure("Creutz, Dragsvik", "http://ruokalistat.leijonacatering.fi/rss/2/1/65b125f6-f713-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Rokka, Hamina", "http://ruokalistat.leijonacatering.fi/rss/2/1/a5cbc816-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Ignatius, Helsinki", "http://ruokalistat.leijonacatering.fi/rss/2/1/25b89e42-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Sahara, Helsinki", "http://ruokalistat.leijonacatering.fi/rss/2/1/549339f9-e510-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Hilma, Helsinki", "http://ruokalistat.leijonacatering.fi/rss/2/1/55949a7b-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Hoikanhovi, Kajaani", "http://ruokalistat.leijonacatering.fi/rss/2/1/c56d6724-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Rakuuna, Lappeenranta", "http://ruokalistat.leijonacatering.fi/rss/2/1/65494b38-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Falkonetti, Niinisalo", "http://ruokalistat.leijonacatering.fi/rss/2/1/25022d4c-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Ruben, Parolannummi", "http://ruokalistat.leijonacatering.fi/rss/2/1/65071957-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Sääksi, Pirkkala", "http://ruokalistat.leijonacatering.fi/rss/2/1/05b0c494-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Liesi, Riihimäki", "http://ruokalistat.leijonacatering.fi/rss/2/1/95b4bc5d-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Somero, Rovaniemi", "http://ruokalistat.leijonacatering.fi/rss/2/1/95788a67-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Tähti, Sodankylä", "http://ruokalistat.leijonacatering.fi/rss/2/1/351a0772-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Rumpalipoika, Säkylä", "http://ruokalistat.leijonacatering.fi/rss/2/1/25f04a86-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Luonetti, Tikkakoski", "http://ruokalistat.leijonacatering.fi/rss/2/1/2576a07c-f913-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Cirrus, Toivala", "http://ruokalistat.leijonacatering.fi/rss/2/1/1523c930-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Poiju, Turku", "http://ruokalistat.leijonacatering.fi/rss/2/1/35121e9f-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Ankkuri, Upinniemi","http://ruokalistat.leijonacatering.fi/rss/2/1/7566faa6-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Kotka, Utti", "http://ruokalistat.leijonacatering.fi/rss/2/1/85a09ab2-f813-e511-892b-78e3b50298fc"),
            new RestaurantsStructure("Linna, Vekaranjärvi", "http://ruokalistat.leijonacatering.fi/rss/2/1/25b3a8ba-f813-e511-892b-78e3b50298fc")
        });

        // Exception List for Meal Titles
        public static List<string> MenuExceptionList = new List<string>(new string[]
        {
            "henkilö",
            "kajnetti_1",
            "suo_asiakas1",
            "sodas_1"
        });
    }
}
