﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class PlayerModel : BaseModel
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public long ClubId { get; set; }

        public virtual ClubModel Club { get; set; }
        public virtual IEnumerable<CardModel> Cards { get; set; }
        public virtual IEnumerable<GoalModel> Goals { get; set; }

    }
}
