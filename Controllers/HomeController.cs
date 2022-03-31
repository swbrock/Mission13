using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
       // private IBowlerRepository repo;
        private BowlingLeagueExampleDbContext blContext { get; set; }
        public HomeController(BowlingLeagueExampleDbContext someName)//, IBowlerRepository temp
        {
            blContext = someName;
            //repo = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BowlerList(int TeamID)
        {

            //var dataset = repo.Bowler
            //    .Include("Teams")
            //    .Where(b => b.Team.TeamID == TeamID || TeamID == 0)
            //    .OrderBy(b => b.BowlerLastName)
            //    .ToList();
            //return View(dataset);

            ViewBag.Teams = blContext.Teams.ToList();


            var bowlers = blContext.Bowlers
                .Include(x => x.Team)
                .OrderBy(x => x.Team.TeamName)
                .ToList();
            return View(bowlers);
        }
        [HttpGet]
        public IActionResult EnterBowler()
        {
            ViewBag.Teams = blContext.Teams.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult EnterBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                blContext.Add(b);
                blContext.SaveChanges();
                return View("Index", b);
            }
            else
            {
                ViewBag.Teams = blContext.Teams.ToList();
                return View(b);
            }
            //Puts what the user just inserted in the new bowler into the database
        }
        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = blContext.Teams.ToList();

            var bowlers = blContext.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View("EnterBowler", bowlers);
        }
        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            blContext.Update(b);
            blContext.SaveChanges();
            return RedirectToAction("BowlerList");
        }
        public IActionResult Delete(int bowlerid)
        {
            var bowler = blContext.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View(bowler);
        }
        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            blContext.Bowlers.Remove(b);
            blContext.SaveChanges();

            return RedirectToAction("BowlerList");
        }
    }
}