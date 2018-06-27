using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class PlayerModel
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ClubModel Club { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
    }
}
