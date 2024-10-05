namespace Computing_Project_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //var players = DataReaders.ReadBatters();
            //Console.WriteLine(players[0].FirstName +" " + players[0].LastName);

            //DataReaders.CreateTeams();

            var bases = new Bases(new Team("team a",new List<int> {1,2,3},new List<int> {4,5,6}));
            bases.SetAtPlate(new Batter("john", "doe", new float[] { 0.123f, 0.81f }));

            for (int i = 0; i < 50; i++)
            {
                var outcome = Pitch.Pitchball(0, 0, new Pitcher("john", "doe", new float[] { 0.123f, 0.81f }), new Batter("jane", "doe", new float[] { 0.123f, 0.81f }));
                Console.WriteLine(outcome.ToString());
            }
        } 
    }
}
