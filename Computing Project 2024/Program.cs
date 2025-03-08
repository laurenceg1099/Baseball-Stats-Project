namespace Computing_Project_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {

                var teams = DataReaders.CreateTeams();
                var season = new Season(teams);
                //season.StartSeaon();

                var p= DataReaders.ReadPitchers().OrderByDescending(x => x.AbilityScore).ToList();

                Analysis analysis = new Analysis(DataReaders.ReadBatters(), DataReaders.ReadPitchers());






        }
    }
}
