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
            DataViewModel Model = new DataViewModel();
            Model.Goals = _db.Goals
                .Where(g => g.MatchId == id)
                .OrderBy(g => g.Minute)
                .Include(g => g.Player)
                .ToList();
            
            Model.Cards = _db.Cards
                .Where(c => c.MatchId == id)
                .OrderBy(c => c.Minute)
                .Include(c => c.Player)
                .ToList();

            Model.Match = _db.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Referee)
                .Include(m => m.Season)
                .Single(m => m.Id == id);

            return View(Model);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            DataViewModel Model = new DataViewModel();
            Model.Clubs = _db.Clubs.ToList();
            Model.Referees = _db.Referees.ToList();
            Model.Seasons = _db.Seasons.ToList();
            return View(Model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Details(DataViewModel Model)
        {
            _db.Matches.Add(Model.Match);
            _db.SaveChanges();

            Model.Players = _db.Players
                .Where(p => (p.ClubId == Model.Match.HomeTeamId || p.ClubId == Model.Match.AwayTeamId))
                .ToList();
            return View(Model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Insert(DataViewModel Model)
        {
            if (Model.Goals != null)
            {
                foreach (var goal in Model.Goals)
                {
                    _db.Goals.Add(goal);
                }
            }
            if (Model.Cards != null)
            {
                foreach (var card in Model.Cards)
                {
                    _db.Cards.Add(card);
                }
            }


            _db.SaveChanges();
            return Redirect("/Home/Results");
        }

        [Route("Match/Edit/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            DataViewModel Model = new DataViewModel();

            Model.Match = _db.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Referee)
                .Include(m => m.Season)
                .Single(m => m.Id == id);

            Model.Clubs = _db.Clubs.ToList();
            Model.Referees = _db.Referees.ToList();
            Model.Seasons = _db.Seasons.ToList();

            return View(Model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult EditDetails(DataViewModel Model)
        {
            var match = _db.Matches.Single(m => m.Id == Model.Match.Id);
            if (
               match.HomeTeamGoals == Model.Match.HomeTeamGoals &&
               match.AwayTeamGoals == Model.Match.AwayTeamGoals &&
               match.HomeTeamYellowCards == Model.Match.HomeTeamYellowCards &&
               match.HomeTeamRedCards == Model.Match.HomeTeamRedCards &&
               match.AwayTeamRedCards == Model.Match.AwayTeamRedCards &&
               match.AwayTeamYellowCards == Model.Match.AwayTeamYellowCards
               )
            {
                if (match.RefereeId != Model.Match.RefereeId)
                {
                    match.RefereeId = Model.Match.RefereeId;
                    _db.SaveChanges();
                }
                if (match.Date != Model.Match.Date)
                {
                    match.Date = Model.Match.Date;
                    _db.SaveChanges();
                }
                if (match.SeasonId != Model.Match.SeasonId)
                {
                    match.SeasonId = Model.Match.SeasonId;
                    _db.SaveChanges();
                }
                DataViewModel DataModel = new DataViewModel();
                DataModel = Model;
                DataModel.Players = _db.Players
                    .Where(p => (p.ClubId == Model.Match.HomeTeamId || p.ClubId == Model.Match.AwayTeamId))
                    .ToList();
                DataModel.Cards = _db.Cards
                    .Where(c => c.MatchId == Model.Match.Id)
                    .ToList();
                DataModel.Goals = _db.Goals
                    .Where(c => c.MatchId == Model.Match.Id)
                    .ToList();
                
                return View(DataModel);
            }
            else
            {
                match.HomeTeamId = Model.Match.HomeTeamId;
                match.AwayTeamId = Model.Match.AwayTeamId;
                match.HomeTeamGoals = Model.Match.HomeTeamGoals;
                match.AwayTeamGoals = Model.Match.AwayTeamGoals;
                match.HomeTeamYellowCards = Model.Match.HomeTeamYellowCards;
                match.HomeTeamRedCards = Model.Match.HomeTeamRedCards;
                match.AwayTeamYellowCards = Model.Match.AwayTeamYellowCards;
                match.AwayTeamRedCards = Model.Match.AwayTeamRedCards;
                match.RefereeId = Model.Match.RefereeId;
                match.Date = Model.Match.Date;
                match.SeasonId = Model.Match.SeasonId;

                DataViewModel DataModel = new DataViewModel();
                DataModel = Model;
                DataModel.Players = _db.Players
                    .Where(p => (p.ClubId == Model.Match.HomeTeamId || p.ClubId == Model.Match.AwayTeamId))
                    .ToList();

                
                var cards = _db.Cards.Where(c => c.MatchId == match.Id);
                var goals = _db.Goals.Where(g => g.MatchId == match.Id);

                foreach (var card in cards)
                {
                    _db.Cards.Remove(card);
                }
                foreach (var goal in goals)
                {
                    _db.Goals.Remove(goal);
                }
                _db.SaveChanges();
                return View("Details", DataModel);
            }            
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Update(DataViewModel Model)
        {
            if (Model.Cards != null && Model.Cards.Any())
            {
                _db.Cards.UpdateRange(Model.Cards);
            }
            if (Model.Goals != null && Model.Goals.Any())
            {
                _db.Goals.UpdateRange(Model.Goals);
            }


            _db.SaveChanges();
            return Redirect("/Home/Results");
        }

        [Route("Match/Delete/{id:int}")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var match = _db.Matches.Single(m => m.Id == id);
            var cards = _db.Cards.Where(c => c.MatchId == id);
            var goals = _db.Goals.Where(g => g.MatchId == id);

            _db.Cards.RemoveRange(cards);
            _db.Goals.RemoveRange(goals);
            _db.Matches.Remove(match);
            _db.SaveChanges();
            return Redirect("/Home/Results");
        }
    }
}