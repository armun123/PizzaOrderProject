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
        PizzaDBEntities1 _db;

        public HomeController()
        {
            _db = new PizzaDBEntities1();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Please Make An Order";
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            ViewData.Model = _db.tbl_orders.ToList();
            ViewBag.Message = "Thank You For Your Order!";
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(FormCollection form)
        {
            var orderToAdd = new tbl_orders();

            // Deserialize (Include white list!)
            TryUpdateModel(orderToAdd, new string[] { "Date", "Count" }, form.ToValueProvider());

            // Validate
            if (String.IsNullOrEmpty(orderToAdd.deliveredDate.ToString()))
                ModelState.AddModelError("Delivery Date", "DeliveryDate is required!");
            if (String.IsNullOrEmpty(orderToAdd.countPZ.ToString()))
                ModelState.AddModelError("Count", "Count of Pizzas is required!");

            // If valid, save movie to database
            if (ModelState.IsValid)
            {
                //_db.AddToOrderSet(orderToAdd);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Otherwise, reshow form
            return View(orderToAdd);
        }
        //GET: Home/ordersPage
        public ActionResult OrdersPage()

        {

            return View();

        }
    }
}