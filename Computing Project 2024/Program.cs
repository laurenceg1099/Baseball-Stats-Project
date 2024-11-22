namespace Computing_Project_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var teams = DataReaders.CreateTeams();
            foreach (var item in teams)
            {
                //Console.WriteLine($"{item.Name} : {item.PitchingRoster.First()},{item.BattingRoster.First()}");
                Console.WriteLine($"{item.nextbatter()},{item.currentPitcher}");
            }

            
        } 
    }
}
