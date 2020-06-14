using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAppMVC.Controllers
{
    public class CustomController : Controller
    {
        // GET: Custom
        public ActionResult Index()
        {
            ViewBag.Message = "Это находится в контроллере Custom метод Index";
            return View();
        }
        public ActionResult MyPage()
        {
            ViewBag.Message = "Это находится в контроллере Custom метод MyPage";
            return View();
        }

    }
}