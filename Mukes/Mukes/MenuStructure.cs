namespace Mukes.Core
{
    public class MenuStructure
    {
        public string Title { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
        public string EveningSnack { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="description">Description</param>
        public MenuStructure(string title, string breakfast, string lunch, string dinner, string eveningSnack)
        {
            Title = title;
            Breakfast = breakfast;
            Lunch = lunch;
            Dinner = dinner;
            EveningSnack = eveningSnack;
        }
    }
}
