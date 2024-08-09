using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Computing_Project_2024
{
    public static class DataReaders
    {

        private const string dataDir = @"C:\Users\Laurence\source\repos\Computing Project 2024\Computing Project 2024\Data";
        private static string data => Path.Combine(dataDir, "Battingstats1.csv");

       
        static public List<Player> ReadPlayers()
        {
            List<Player> list = new List<Player>();
            using (var reader = new StreamReader(data))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().ToString().Split(",");
                    list.Add(new Player(line[1], line[0], Array.ConvertAll(line[1..-1], x => float.Parse(x))));
                }
            }
            return list;
        }


        static public List<Team> CreateTeams() 
        {
            foreach (string file in Directory.EnumerateFiles(dataDir, "*"))
            {
                Console.WriteLine(file);
                string lines = File.ReadAllText(file);
                
            }

            return new List<Team>();
        }


        static public List<Player> ReadBatters()
        {
            List<Player> list = new List<Player>();
            var lines = File.ReadAllLines(data);
            {
                foreach( var line in lines.Skip(1) ) 
                {
                    var temp = line.Split(",");   
                    var fields = temp.Select(x => x.Trim('"')).ToArray();
                    list.Add(new Player(fields[1].Trim(), fields[0].Trim(), fields[4..].Select(x => float.Parse(x)).ToArray())); 
                }
            }
            return list;
        }

        static public List<Player> ReadPitchers()
        {
            List<Player> list = new List<Player>();
            var lines = File.ReadAllLines(data);
            {
                foreach (var line in lines.Skip(1))
                {
                    var temp = line.Split(",");
                    var fields = temp.Select(x => x.Trim('"')).ToArray();
                    list.Add(new Player(fields[1].Trim(), fields[0].Trim(), fields[4..].Select(x => float.Parse(x)).ToArray()));
                }
            }
            return list;
        }


    }
}
