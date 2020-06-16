using MyAppMVC.Models;
using MyAppMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
			var row = TeamsRepositipy.GetTeamFromCollection(id);
			if(row == null)
			{
				return HttpNotFound();
			}
			return View(row);
		}

		public ActionResult DeleteRow(int id)
		{
			TeamsRepositipy.DeleteRow(id);
			return View();
			//Redirect("/") возвращает на роут по умолчанию
		}

		[HttpGet]
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
			return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
		}

		// вот таким образом deadblock возникать не будет!!!!!!!
		// Тут 2 примера , не принимайте за мусор
		//public async Task<string> RunNewTask()
		//{
		//	return await Task.Run(() => { Thread.Sleep(5000); return "Это пришло из async"; });
		//}
		public async Task<ActionResult> AsynkAction()
		{
			//var result = await RunNewTask();
			var result = await Task.Run(() => { Thread.Sleep(5000); return "Это пришло из async"; });
			return View((object)result);
		}
	}
}