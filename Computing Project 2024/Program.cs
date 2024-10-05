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
            bases.PrintBases();
            bases.walk(0);
            bases.PrintBases();
            bases.walk(1);
            bases.PrintBases();
            bases.walk(2);
            bases.PrintBases();
            bases.walk(3);
            bases.PrintBases();
        } 
    }
}
