using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Task_1_with_Identity.Models;


namespace Task_1_with_Identity.Controllers
{
    public class AdminController : Controller
    {
        Model1 db = new Model1();

        // GET: Admin
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(new AdminManageView());
        }
        
        [HttpPost]
        public ActionResult EditUserPartical(Buyer model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageUser", new { id = model.Id });
            }


            return RedirectToAction("ManageUser", new {id = model.Id });
        }

        [Authorize(Roles ="admin")]
        public ActionResult ManageUser(int? id)
        {
            if (id != null)
            {
                Buyer buyer = db.Buyer.Where(b => b.Id == id).SingleOrDefault();

                return View(buyer);
            }
            else return RedirectToAction("Index");
        }


        public ActionResult DeleteFromCart(int id, int idUser)
        {
            Cart c = new Cart();
            c.Id = id;
            db.Cart.Attach(c);
            db.Cart.Remove(c);
            db.SaveChanges();
            return RedirectToAction("ManageUser", new {id = idUser });
        }

        public ActionResult DeleteFromBuy(int id, int idUser)
        {
            Buy b = new Buy();
            b.Id = id;
            db.Buy.Attach(b);
            db.Buy.Remove(b);
            db.SaveChanges();


            return RedirectToAction("ManageUser", new { id = idUser });
        }
    }
}