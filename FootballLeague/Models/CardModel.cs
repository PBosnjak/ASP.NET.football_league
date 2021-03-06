﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class CardModel : BaseModel
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public int Minute { get; set; }
        public long MatchId { get; set; }
        public long PlayerId { get; set; }

        public virtual MatchModel Match { get; set; }
        public virtual PlayerModel Player { get; set; }
    }
}
