using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class GoalModel
    {
        public long Id { get; set; }
        public long MatchId { get; set; }
        public long PlayerId { get; set; }
        public int Minute { get; set; }
        public int Halftime { get; set; }

    }
}
