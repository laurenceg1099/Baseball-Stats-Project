namespace Computing_Project_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s1 = 0;
            var s2 = 0;
            var teams = DataReaders.CreateTeams();

            for (int i = 0; i < 1000; i++) {
                var game2 = new Game(teams[2], teams[29], 9);
                s1 += game2.HomeScore;
                s2 += game2.AwayScore;

               // Console.WriteLine($"{game2.HomeScore}:{game2.AwayScore}");

            }
            Console.WriteLine($"{teams[2].Name}:{teams[29].Name}");
            
            Console.WriteLine($"{(double)s1/1000}:{(double)s2/1000}");


        }
    }
}
