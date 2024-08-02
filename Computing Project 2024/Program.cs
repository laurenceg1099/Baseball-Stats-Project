namespace Computing_Project_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var players = Constructors.ConstructPlayers2();
            Console.WriteLine(players[0].FirstName +" " + players[0].LastName);
        }
    }
}
