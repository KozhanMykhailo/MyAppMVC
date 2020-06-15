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

		public RedirectResult SaveRow(Team team)
		{
			if (TeamsRepositipy.TeamsCollection.Contains(team))
				TeamsRepositipy.UpdateDataTeam(team);
			else
				TeamsRepositipy.CreateRow(team);
			return Redirect("TeamsEdit");
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
			ViewBag.Message = "Your contact page.";
			return View();
		}

	}
}