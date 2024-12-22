namespace Computing_Project_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var teams = DataReaders.CreateTeams();
            var game2 = new Game(teams[0], teams[1], 9);
            Console.WriteLine($"{game2.HomeScore}:{game2.AwayScore}");

        }
    }
}
