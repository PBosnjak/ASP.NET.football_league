using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballLeague.Models;
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
    }
}