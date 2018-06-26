using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class MatchDataContext : DbContext
    {
        public DbSet<MatchModel> Matches { get; set; }

        public MatchDataContext(DbContextOptions<MatchDataContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public IEnumerable<MatchModel> GetMatchData()
        {
            return new[]
            {
                new MatchModel
                {
                    Date = DateTime.Now,
                    AwayTeam = "Dinamo",
                    AwayTeamGoals = 1,
                    HomeTeam = "Osijek",
                    HomeTeamGoals = 2
                },
                new MatchModel
                {
                    Date = DateTime.Now,
                    AwayTeam = "Hajduk",
                    AwayTeamGoals = 1,
                    HomeTeam = "Osijek",
                    HomeTeamGoals = 2
                }
            };
        }
    }
}
