using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class GoalModel : BaseModel
    {
        public long Id { get; set; }
        public int Minute { get; set; }
        public int Halftime { get; set; }
        public long MatchId { get; set; }
        public long PlayerId { get; set; }

        public virtual MatchModel Match { get; set; }
        public virtual PlayerModel Player { get; set; }

    }
}
