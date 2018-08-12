using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class MatchModel
    {
        public long Id { get; set; }
        public string Season { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public int HomeTeamRedCards { get; set; }
        public int HomeTeamYellowCards { get; set; }
        public int AwayTeamRedCards { get; set; }
        public int AwayTeamYellowCards { get; set; }
        public long HomeTeamId { get; set; }
        public long AwayTeamId { get; set; }
        public long RefereeId { get; set; }

        public virtual ClubModel HomeTeam { get; set; }
        public virtual ClubModel AwayTeam { get; set; }
        public virtual RefereeModel Referee { get; set; }
        public virtual IEnumerable<GoalModel> Goals { get; set; }
        public virtual IEnumerable<CardModel> Cards { get; set; }
    }
}
