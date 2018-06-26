using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FootballLeague.Models;

namespace FootballLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly MatchDataContext _db;

        public HomeController(MatchDataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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

        [Route("/create")]
        public IActionResult Create()
        {
            var matches = _db.GetMatchData();
            foreach (var match in matches)
                _db.Matches.Add(match);
            _db.SaveChanges(); 
            return View("About");
        }
    }
}
