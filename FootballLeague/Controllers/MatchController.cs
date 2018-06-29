using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballLeague.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Controllers
{
    public class MatchController : Controller
    {
        private readonly DataContext _db;

        public MatchController(DataContext db)
        {
            _db = db;
        }

        [Route("Match/{id:int}")]
        public IActionResult Index(int id)
        {
            CardGoalViewModel CGVM = new CardGoalViewModel();
            CGVM.Goals = _db.Goals
                .Where(g => g.MatchId == id)
                .OrderBy(g => g.Minute)
                .Include(g => g.Player)
                .ToList();
            
            CGVM.Cards = _db.Cards
                .Where(c => c.MatchId == id)
                .OrderBy(c => c.Minute)
                .Include(c => c.Player)
                .ToList();

            CGVM.Match = _db.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Referee)
                .Single(m => m.Id == id);

            return View(CGVM);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            CardGoalViewModel CGVM = new CardGoalViewModel();
            CGVM.Clubs = _db.Clubs;            
            return View(CGVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Details(CardGoalViewModel CGVM)
        {
            CGVM.Match.Date = DateTime.Now;
            CGVM.Match.RefereeId = 1;
            CGVM.Match.Season = "2017/18";
            _db.Matches.Add(CGVM.Match);
            _db.SaveChanges();

            CGVM.Players = _db.Players
                .Where(p => (p.ClubId == CGVM.Match.HomeTeamId || p.ClubId == CGVM.Match.AwayTeamId))
                .ToList();
            return View(CGVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Insert(
            long[] HomeTeamPlayer, 
            long[] AwayTeamPlayer, 
            int[] MinuteHome, 
            int[] HalftimeHome,
            int[] MinuteAway,
            int[] HalftimeAway
            )
        {
            int Counter = 0;
            int HomeTeamGoals = 0;
            int AwayTeamGoals = 0;
            var LastDbEntry = _db.Matches.Last();

            foreach (var item in HomeTeamPlayer)
            {
                HomeTeamGoals++;

                var Goal = new GoalModel
                {
                    MatchId = LastDbEntry.Id,
                    PlayerId = item,
                    Minute = MinuteHome[Counter],
                    Halftime = HalftimeHome[Counter]
                };
                Counter++;
                _db.Goals.Add(Goal);

            }

            Counter = 0;

            foreach (var item in AwayTeamPlayer)
            {
                AwayTeamGoals++;

                var Goal = new GoalModel
                {
                    MatchId = LastDbEntry.Id,
                    PlayerId = item,
                    Minute = MinuteAway[Counter],
                    Halftime = HalftimeAway[Counter]
                };
                Counter++;
                _db.Goals.Add(Goal);

            }


            LastDbEntry.HomeTeamGoals = HomeTeamGoals;
            LastDbEntry.AwayTeamGoals = AwayTeamGoals;
            _db.SaveChanges();

            return Redirect("/");
        }
    }
}