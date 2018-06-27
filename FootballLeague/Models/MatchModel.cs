using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class MatchModel
    {
        public long Id { get; set; }
        public string Season { get; set; }
        public DateTime Date { get; set; }
        public ClubModel HomeTeam { get; set; }
        public ClubModel AwayTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public RefereeModel Referee { get; set; }
        public int HomeTeamRedCards { get; set; }
        public int HomeTeamYellowCards { get; set; }
        public int AwayTeamRedCards { get; set; }
        public int AwayTeamYellowCards { get; set; }

    }
}
