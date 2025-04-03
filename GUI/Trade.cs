namespace Computing_Project_2024
{
    public class Trade
    {
        private Team _team1;
        private Team _team2;
        private List<Player> _players1;
        private List<Player> _players2;
        Trade(Team team1, Team team2 , List<Player> players1, List<Player> players2)
        {
            _team1 = team1;
            _team2 = team2;
            _players1 = players1;
            _players2 = players2;
            
        }

        //public bool DoTrade()
        //{
        //    if (!checkTrade()) {return false;}
        //    double Probability = calculateValues();

        //    var r = new Random().NextDouble();
        //    if(r< Probability)
        //    {
        //        CompleteTrade();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

            
        //}

        //private bool checkTrade()
        //{
        //    if(_players1.Count() + _players2.Count() > 10) { return false; }
        //    if (!_team1.CheckCap(_players1, _players2) || !_team2.CheckCap(_players1, _players2)) { return false;}
        //}
    }
}
