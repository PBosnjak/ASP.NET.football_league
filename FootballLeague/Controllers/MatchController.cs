using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.Controllers
{
    public class MatchController : Controller
    {
        [Route("Match/{id:int}")]
        public IActionResult Index(int id)
        {
            ViewData["id"] = id;
            return View();
        }
    }
}