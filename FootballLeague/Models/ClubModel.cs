﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class ClubModel : BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public IEnumerable<MatchModel> Matches { get; set; }

        [NotMapped]
        public int CurrentPoints { get; set; }
        [NotMapped]
        public int Wins { get; set; }
        [NotMapped]
        public int Draws { get; set; }
        [NotMapped]
        public int Losses { get; set; }
        [NotMapped]
        public int GamesPlayed { get; set; }
    }
}
