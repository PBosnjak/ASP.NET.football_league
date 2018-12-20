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
        private readonly IClubRepository ClubRepository;


        public HomeController(DataContext db, IClubRepository clubRepository)
        {
            _db = db;
            ClubRepository = clubRepository;
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

        public IActionResult Results(int page = 0)
        {
            var pageSize = 10;
            var totalPosts = _db.Matches.Count();
            var totalPages = totalPosts / pageSize + 1;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var p = _db.Matches
                .OrderByDescending(x => x.Date)
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .Include(x => x.Season)
                .Skip(pageSize * page)
                .Take(pageSize)
                .ToList();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(p);

            return View(p);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Club()
        {
            var klub = new ClubModel()
            {
                Country = "hrv",
                Name = "inker"
            };

            await ClubRepository.Create(klub);
            return RedirectToAction("Index");
        }

    }
}
