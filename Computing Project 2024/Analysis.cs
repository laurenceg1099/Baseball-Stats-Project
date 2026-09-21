using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computing_Project_2024
{
    public class Analysis
    {
        private string path = Path.Combine(AppContext.BaseDirectory, "Data", "NameSalaryData.csv");
        private Dictionary<string, int> namesalary = new Dictionary<string, int>();
        private Dictionary<string, double> p_nameability = new Dictionary<string, double>();
        private Dictionary<string, double> b_nameability = new Dictionary<string, double>();

        public Analysis(List<Batter> batters, List<Pitcher> pitchers)
        {
            foreach (var batter in batters)
            {
                b_nameability.Add($"{batter.FirstName.Trim()} {batter.LastName}", batter.AbilityScore);
            }
            foreach (var pitcher in pitchers)
            {
                if (p_nameability.ContainsKey($"{pitcher.FirstName.Trim()} {pitcher.LastName}"))
                {
                    continue;
                }
                else
                {
                    p_nameability.Add($"{pitcher.FirstName.Trim()} {pitcher.LastName}", pitcher.AbilityScore);
                }
            }

            ReadSalary();
            var battersdata = GetSalaryAbility(b_nameability);
            var pitchersdata = GetSalaryAbility(p_nameability);

            var batterpath = Path.Combine(AppContext.BaseDirectory, "Data", "pitcherdata.csv");

            using (StreamWriter writer = new StreamWriter(batterpath))
            {
                // Write each key-value pair
                foreach (var kvp in battersdata)
                {
                    writer.WriteLine($"{kvp.Value.Item1},{kvp.Value.Item2}");
                }       
            }

        }

        private void ReadSalary()
        {
            var salary = System.IO.File.ReadAllLines(path).Select(x => x.Split(",")).ToList();
            foreach (var line in salary)
            {
                if (namesalary.ContainsKey(line[0]))
                {
                    continue;
                }
                else
                {
                    namesalary.Add(line[0], int.Parse(line[2]));
                }
            }
        }

        
        private Dictionary<string, Tuple<double,int>> GetSalaryAbility(Dictionary<string,double> table1)
        {
            var newdict = new Dictionary<string, Tuple<double, int>>();
            foreach (var player in table1)
            {
                if (namesalary.ContainsKey(player.Key))
                {
                    newdict.Add(player.Key,new Tuple<double, int>(player.Value, namesalary[player.Key]));
                }
                
            }

            return newdict;
        }



    }
}
