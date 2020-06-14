using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAppMVC.Models;

namespace MyAppMVC.Controllers
{
    public class CustomController : Controller
    {
        // GET: Custom
        public ActionResult Index()
        {
            ViewBag.Message = "Это находится в контроллере Custom метод Index";
            using (MatchesContext db = new MatchesContext())
            {
                var users = db.Players;
                var teams = db.Teams;
                var gemaplayers = db.GemaPlayers;
                var matches = db.Matches;
                List<Team> lt = new List<Team>();
                foreach (var item in teams)
                {
                    lt.Add(new Team() { TeamName = item.TeamName, City = item.City, Id = item.Id });
                }              
                return View(lt);
            }
        }
        public ActionResult MyPage()
        {
            ViewBag.Message = "Это находится в контроллере Custom метод MyPage";
            return View();
        }

    }
}