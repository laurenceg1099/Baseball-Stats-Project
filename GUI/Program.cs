using Computing_Project_2024;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var teams = DataReaders.CreateTeams();
            var season = new Season(teams);
            ApplicationConfiguration.Initialize();
            Application.Run(new MainMenu(season));


            //season.StartSeaon();


        }
    }
}