using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class DataViewModel
    {
        public IList<GoalModel> Goals { get; set; }
        public IList<CardModel> Cards { get; set; }
        public IList<ClubModel> Clubs { get; set; }
        public IList<PlayerModel> Players { get; set; }
        public IList<RefereeModel> Referees { get; set; }
        public IList<SeasonModel> Seasons { get; set; }
        public MatchModel Match { get; set; }
    }
}
