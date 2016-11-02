using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Mvc_5_Empty_Template1.Models;


namespace Mvc_5_Empty_Template1.Controllers
{
    public class HomeController : Controller
    {
        private PizzaDBEntities1 dbe = new PizzaDBEntities1();
        // GET: Home

        public HomeController()
        {
        }

        public ActionResult Index()
        {

            ViewBag.Message = "Please Make An Order";
            return View();
        }
        [HttpPost]
        public ActionResult Index(order order)
        {
            try
            {
                string phone = order.phone;
                tbl_Users user = dbe.tbl_Users.Where(item => item.phone == phone).FirstOrDefault();
                if (user == null)
                {
                    tbl_Users newUser = new tbl_Users();
                    newUser.firstName = order.firstName;
                    newUser.lastName = order.lastName;
                    newUser.phone = order.phone;
                    newUser.userEmail = order.userEmail;
                    dbe.tbl_Users.Add(newUser);
                    dbe.SaveChanges();
                    user = dbe.tbl_Users.Where(item => item.phone == phone).FirstOrDefault();
                }
                tbl_orders newOrder = new tbl_orders();
                newOrder.countPZ = Convert.ToInt32(order.countPZ);
                newOrder.deliveredDate = Convert.ToDateTime(order.deliveredDate);
                newOrder.userId = user.userId;
                dbe.tbl_orders.Add(newOrder);
                dbe.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
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
                dbe.SaveChanges();
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

        [HttpPost]
        public ActionResult Search(FormCollection form)
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrdersPage(FormCollection form)
        {
            return View();
        }
    }
}