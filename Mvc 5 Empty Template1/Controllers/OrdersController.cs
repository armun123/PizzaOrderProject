using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5_Empty_Template1.Models;

namespace Mvc_5_Empty_Template1.Controllers
{
    public class OrdersController : Controller
    {
        private PizzaDBEntities1 dbe = new PizzaDBEntities1();
        // GET: Orders

        public ActionResult Index()
        {
            List<order> orders = new List<order>();

            return View();
        }

        //GET: Home/ordersPage
        public ActionResult OrdersPage()

        {

            return View();

        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string phone = form["phone"];
            PizzaDBEntities1 dbe = new PizzaDBEntities1();
            List<order> orders = new List<order>();
            orders = dbe.tbl_orders
                .Join(dbe.tbl_Users, item => item.userId, item => item.userId, (outer, inner) => new { Outer = outer, Inner = inner })
                .Where(item => item.Inner.phone == phone)
                .OrderBy(item => item.Outer.deliveredDate)
                .AsEnumerable()
                .Select(item => new order
                {
                    firstName = item.Inner.firstName,
                    lastName = item.Inner.lastName,
                    phone = item.Inner.phone,
                    userEmail = item.Inner.userEmail,
                    deliveredDate = item.Outer.deliveredDate,
                    countPZ = item.Outer.countPZ
                })
                .ToList();
            return View(orders);
        }
    }
}