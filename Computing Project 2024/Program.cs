namespace Computing_Project_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var batters = DataReaders.ReadBatters();
            var pitchers = DataReaders.ReadPitchers();
            var teams = DataReaders.CreateTeams();
            var i = 1;
            foreach (var item in teams)
            {
                item.sortPlayers(batters, pitchers);
                Console.WriteLine($"{i} : {item.Name} , {item.PitchingRoster.Count()},{item.BattingRoster.Count()}");
                i++;
            }

            
        } 
    }
}
