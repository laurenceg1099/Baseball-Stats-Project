namespace Computing_Project_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var teams = DataReaders.CreateTeams();
            var season = new Season(teams);


        }
    }
}
