using System.Collections.Generic;

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

        public static List<string> Veckodag = new List<string>(new string[] {
            "Måndag",
            "Tisdag",
            "Onsdag",
            "Torsdag",
            "Fredag",
            "Lördag",
            "Söndag"
        });

        public static List<string> DateFormats = new List<string>(new string[]
        {
            @"(?<day>\d{2}).(?<month>\d{2}).(?<year>\d{4})", // 00.00.0000
            @"(?<day>\d{2}).(?<month>\d{1}).(?<year>\d{4})", // 00.0.0000
            @"(?<day>\d{1}).(?<month>\d{2}).(?<year>\d{4})", // 0.00.0000
            @"(?<day>\d{1}).(?<month>\d{1}).(?<year>\d{4})", // 0.0.0000
            @"(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})" // 0000-00-00

        });

        public enum Meals { Breakfast, Lunch, Dinner, EveningSnack };

        public static List<string> MealsFI = new List<string>(new string[]
        {
            "Aamupala",
            "Lounas",
            "Päivällinen",
            "Iltapala"
        });

        public static List<string> MealsEN = new List<string>(new string[]
        {
            "Breakfast",
            "Lunch",
            "Dinner",
            "Supper"
        });

        public static List<string> MealsSV = new List<string>(new string[]
{
            "Frukost",
            "Lunch",
            "Middag",
            "Kvällsmål"
});

        public static List<RestaurantsStructure> RSSFeed = new List<RestaurantsStructure>(new RestaurantsStructure[]
        {
            new RestaurantsStructure("Creutz, Dragsvik", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/CreutzDragsvik/Rss.aspx?Id=58666569-bd95-42c7-8d3b-7c8fffea819a&DateMode=1"),
            new RestaurantsStructure("Rokka, Hamina", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/RokkaHamina/Rss.aspx?Id=ba55efbe-69a9-438e-8383-b200b0d7178c&DateMode=1"),
            new RestaurantsStructure("Ignatius, Helsinki", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/IgnatiusHelsinki/Rss.aspx?Id=90810632-ebe7-4439-aef9-e9804576084a&DateMode=1"),
            new RestaurantsStructure("Sahara, Helsinki", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/SaharaHelsinki/Rss.aspx?Id=c9b5578e-76b9-4113-adb0-c1b656ebc8fb&DateMode=1"),
            new RestaurantsStructure("Hilma, Suomenlinna", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/HilmaSuomenlinna/Rss.aspx?Id=6b20be5f-8d08-4db5-8b72-9ed10639b12a&DateMode=1"),
            new RestaurantsStructure("Hoikanhovi, Kajaani", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/HoikanhoviKajaani/Rss.aspx?Id=f27aacc5-6165-40f6-9dea-a184c290b129&DateMode=1"),
            new RestaurantsStructure("Rakuuna, Lappeenranta", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/RakuunaLappeenranta/Rss.aspx?Id=6729eca1-938c-4ce1-8601-fa105efd4b42&DateMode=1"),
            new RestaurantsStructure("Falkonetti, Niinisalo", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/FalkonettiNiinisalo/Rss.aspx?Id=15f995bb-ffdd-4409-81cb-a365251be564&DateMode=1"),
            new RestaurantsStructure("Ruben, Parolannummi", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/RubenParola/Rss.aspx?Id=4911192a-210a-477f-93e0-49b14654c1ec&DateMode=1"),
            new RestaurantsStructure("Sääksi, Pirkkala", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/SaaksiPirkkala/Rss.aspx?Id=ebede6f3-85ee-449c-a22e-b51da71d727a&DateMode=1"),
            new RestaurantsStructure("Liesi, Orava", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/LiesiOrava/Rss.aspx?Id=7617e7a3-9a73-4825-b543-e9afe51c44ee&DateMode=1"),
            new RestaurantsStructure("Somero, Rovaniemi", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/SomeroRovaniemi/Rss.aspx?Id=e1fd1a63-70f6-47bb-8dc0-e313d7680bbf&DateMode=1"),
            new RestaurantsStructure("Tähti, Sodankylä", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/TahtiSodankyla/Rss.aspx?Id=9c0e7d5d-96fd-484d-b65d-09dd974afbd5&DateMode=1"),
            new RestaurantsStructure("Rumpalipoika, Säkylä", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/RumpalipoikaSakyla/Rss.aspx?Id=6e0dd88e-f037-4f54-8180-019c046de49e&DateMode=1"),
            new RestaurantsStructure("Luonetti, Tikkakoski", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/LuonettiTikkakoski/Rss.aspx?Id=e3dd1621-cb99-44f9-9993-cdd6ff1b95c7&DateMode=1"),
            new RestaurantsStructure("Cirrus, Kuopio", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/CirrusKuopio/Rss.aspx?Id=d1c1acfb-3b7e-4046-8567-a7e953cad442&DateMode=1"),
            new RestaurantsStructure("Poiju, Turku", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/PoijuTurku/Rss.aspx?Id=018f1caf-e1d8-4ae7-8370-4a6e9bf78974&DateMode=1"),
            new RestaurantsStructure("Ankkuri, Upinniemi","https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/AnkkuriUpinniemi/Rss.aspx?Id=f7f85df9-33d8-4469-976c-79634f7374ce&DateMode=1"),
            new RestaurantsStructure("Kotka, Utti", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/KotkaUtti/Rss.aspx?Id=eee37987-be23-4206-9920-dee167f83099&DateMode=1"),
            new RestaurantsStructure("Linna, Vekaranjärvi", "https://menu.leijonacatering.fi/AromieMenus/FI/Default/Leijona/LinnaVekaranjarvi/Rss.aspx?Id=d763c987-c6fd-4ca9-af8d-5bf6ee2d31ec&DateMode=1")
        });

        // Exception List for Meal Titles
        public static List<string> MenuException = new List<string>(new string[]
        {
            "henkilö",
            "kajnetti_1",
            "suo_asiakas1",
            "sodas_1"
        });

        // Language Options
        public static List<string> Language = new List<string>(new string[]
{
            "Suomi",
            "English",
            "Svenska"
        });
    }
}
