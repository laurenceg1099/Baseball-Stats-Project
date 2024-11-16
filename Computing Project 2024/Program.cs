namespace Computing_Project_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var batters = DataReaders.ReadBatters();
            var pitchers = DataReaders.ReadPitchers();
            var teams = DataReaders.CreateTeams();
            var newlist = pitchers.OrderByDescending(x => x.AbilityScore);
            foreach (var item in newlist.Take(100))
            {
                Console.WriteLine(item.ToString());
            }
        } 
    }
}
