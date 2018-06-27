using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class DataContext : DbContext
    {
        public DbSet<MatchModel> Matches { get; set; }
        public DbSet<PlayerModel> Players { get; set; }
        public DbSet<ClubModel> Clubs { get; set; }
        public DbSet<RefereeModel> Referees { get; set; }
        public DbSet<GoalModel> Goals { get; set; }
        public DbSet<CardModel> Cards { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

    }
}
