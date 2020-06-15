using MyAppMVC.Models;
using MyAppMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAppMVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult TeamsEdit()
		{
			ViewBag.Message = "Your application description page.";				
			return View(TeamsRepositipy.GetTeamsCollection());			
		}

		public ActionResult EditRow(int id)
		{			
			return View(TeamsRepositipy.GetTeamFromCollection(id));
		}

		public ActionResult SaveRow(Team team)
		{
			if (TeamsRepositipy.TeamsCollection.Select(s=>s.Id).Contains(team.Id))
				TeamsRepositipy.UpdateDataTeam(team);
			else
				TeamsRepositipy.CreateRow(team);
			return RedirectToAction("TeamsEdit");
		}
		public ActionResult DetailsRow(int id)
		{
			return View(TeamsRepositipy.GetTeamFromCollection(id));
		}

		public ActionResult DeleteRow(int id)
		{
			TeamsRepositipy.DeleteRow(id);
			return View();
			//Redirect("/") возвращает на роут по умолчанию
		}

		public ActionResult CreateRow()
		{
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message1 = HttpContext.Request.Headers;
			ViewBag.Message2 = HttpContext.Request.HttpMethod;
			ViewBag.Message3 = HttpContext.Request.Url;
			ViewBag.Message4 = HttpContext.CurrentHandler;
			return View();
		}

	}
}