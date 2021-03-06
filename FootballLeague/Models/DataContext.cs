﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<SeasonModel> Seasons { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MatchModel>()
                .HasOne(c => c.HomeTeam)
                .WithMany(m => m.Matches)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CardModel>()
                .HasOne(p => p.Player)
                .WithMany(c => c.Cards)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GoalModel>()
                .HasOne(p => p.Player)
                .WithMany(g => g.Goals)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseModel)entity.Entity).DateCreated = DateTime.UtcNow;
                }

                ((BaseModel)entity.Entity).DateModified = DateTime.UtcNow;
            }
        }

    }
}
