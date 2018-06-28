using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class CardGoalViewModel
    {
        public IEnumerable<GoalModel> Goals { get; set; }
        public IEnumerable<CardModel> Cards { get; set; }
        public MatchModel Match { get; set; }
    }
}
