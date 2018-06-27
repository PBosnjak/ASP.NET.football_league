using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FootballLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _db;

        public HomeController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var p = _db.Clubs;
            foreach (ClubModel c in p)
            {
                foreach(MatchModel m in _db.Matches)
                {
                    if(m.HomeTeamId == c.Id)
                    {
                        if (m.HomeTeamGoals > m.AwayTeamGoals)
                        {
                            c.CurrentPoints += 3;
                            c.Wins++;
                            c.GamesPlayed++;
                        }
                        else if (m.HomeTeamGoals == m.AwayTeamGoals)
                        {
                            c.CurrentPoints += 1;
                            c.Draws++;
                            c.GamesPlayed++;
                        }
                        else
                        {
                            c.Losses++;
                            c.GamesPlayed++;
                        }
                    }
                    else if (m.AwayTeamId == c.Id)
                    {
                        if (m.HomeTeamGoals < m.AwayTeamGoals)
                        {
                            c.CurrentPoints += 3;
                            c.Wins++;
                            c.GamesPlayed++;
                        }
                        else if (m.HomeTeamGoals == m.AwayTeamGoals)
                        {
                            c.CurrentPoints += 1;
                            c.Draws++;
                            c.GamesPlayed++;
                        }
                        else
                        {
                            c.Losses++;
                            c.GamesPlayed++;
                        }
                    }
                }
            }
            return View(p.OrderByDescending(x => x.CurrentPoints));
        }

        public IActionResult Results()
        {
            var p = _db.Matches
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam);

                
            return View(p);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
