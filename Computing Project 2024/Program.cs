namespace Computing_Project_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var batters = DataReaders.ReadBatters();
            var pitchers = DataReaders.ReadPitchers();
            var teams = DataReaders.CreateTeams();
            teams[0].sortPlayers(batters, pitchers);
        } 
    }
}
