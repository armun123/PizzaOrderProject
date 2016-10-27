using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;


namespace Mvc_5_Empty_Template1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "Please Make An Order";
            return View();
        }
        [HttpPost]
        public ActionResult Index(string message)
        {
            ViewBag.Message = "Thank You For Your Order!";
            return View();
        }
        //GET: Home/ordersPage
        public ActionResult OrdersPage()

        {

            return View();

        }
    }
}