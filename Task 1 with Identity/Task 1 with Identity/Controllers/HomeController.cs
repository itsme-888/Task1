using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Task_1_with_Identity.Models;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Task_1_with_Identity.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        int pageSize = 30;


        public ActionResult Index(int? id, int? column, int? state, int? page, string filter)
        {


            if (id != null||state == 0 || state == null)
            {
                page = page ?? 0;
                ViewBag.EnableAddButton = true;
                IEnumerable<Phone> phonesPerPages = Refresh(id).OrderBy(o => o.Name).Skip(((int)page - 1) * pageSize).Take(pageSize);
                PageInfo pageInfo = new PageInfo { PageNumber = (int)page, PageSize = pageSize, TotalItems = Refresh(id).Count() };
                IndexViewModel_ ivm = new IndexViewModel_ { PageInfo = pageInfo, Phones = phonesPerPages };
                if (id != null)
                {
                    ViewBag.H3 = db.Categories.Where(o => o.Id == id).Single().Name;
                    ViewBag.EnableAddButton = false;
                }
                if (state == 0 || state == null)
                {
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("_Items", ivm);

                    }
                    return View(ivm);
                }

                return View(ivm);
            }

            else
            {
                ViewBag.EnableAddButton = true;
                if (filter != null)
                {
                    if (filter.Length > 0)
                    {
                        IEnumerable<Phone> p = Refresh(null);
                        if (column == 0)
                            p = p.Where(o => o.Name.ToUpper().Contains(filter.ToUpper()));
                        else if (column == 1) p = p.Where(o => o.Price == int.Parse(filter));
                        else if (column == 2) p = p.Where(o => o.Description.ToUpper().Contains(filter.ToUpper()));
                        else p = p.Where(o => o.Categories.Name.ToUpper().Contains(filter.ToUpper()));
                        ViewBag.Phones = p;
                        ViewBag.Filter = "По запросу: " + filter + " было найдено: " + p.Count();
                        return View();
                    }
                }
                else
                {
                    ViewBag.Column = column;
                    ViewBag.State = state;
                    ViewBag.Phones = Filter(column, state);
                }

            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, FormCollection form)
        {
            int col = int.Parse(form["column"]);
            return RedirectToAction("Index", new { filter = name, column = col });
        }

        private IEnumerable<Phone> Filter(int? column, int? state)
        {
            IEnumerable<Phone> phones = Refresh(null);

            switch (column)
            {
                case 0:
                    if (state == 1) phones = phones.OrderBy(o => o.Name);
                    else phones = phones.OrderByDescending(o => o.Name);
                    break;
                case 1:
                    if (state == 1) phones = phones.OrderBy(o => o.Price);
                    else phones = phones.OrderByDescending(o => o.Price);
                    break;
                case 2:
                    if (state == 1) phones = phones.OrderBy(o => o.Description);
                    else phones = phones.OrderByDescending(o => o.Description);
                    break;

            }

            return phones;

        }


        private IEnumerable<Phone> Refresh(int? id)
        {
            IEnumerable<Phone> p = db.Phone;
            if (id != null) p = p.Where(m => m.CategoriesId == id);
            return p;
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var remove = (from d in db.Phone
                              where d.Id == id
                              select d).Single();
                db.Phone.Remove(remove);
                db.SaveChanges();
            }
            catch { }


            ViewBag.Phones = Refresh(null);


            return View("Index");
        }
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        [ChildActionOnly]
        public ActionResult GetCategories()
        {
            ViewBag.Category = db.Categories;
            return PartialView(db.Categories);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Add()
        {
            SelectList cat = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Categories = cat;
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Add(Phone add, FormCollection form)
        {
            int id = int.Parse(form["dropdown"]);
            Categories category = db.Categories.Where(m => m.Id == id).Single();
            add.Categories = category;
            db.Phone.Add(add);
            db.SaveChanges();


            ViewBag.Phones = Refresh(null);
            return View("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Buy = db.Buy;


            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult AddBuyer()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddBuyer(Buyer buyer)
        {
            db.Buyer.Add(buyer);
            db.SaveChanges();
            ViewBag.Buyer = db.Buyer;
            return View("Contact");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Contact()
        {
            IEnumerable<Buyer> buyers = db.Buyer;
            ViewBag.Buyer = buyers;
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult DeleteBuyer(int id)
        {
            Buyer buyer = db.Buyer.Where(m => m.Id == id).Single();
            db.Buyer.Remove(buyer);
            db.SaveChanges();

            ViewBag.Buyer = db.Buyer;
            return View("Contact");
        }

        [Authorize(Roles = "user")]
        public ActionResult FeedBack()
        {
            if(HttpContext.User.IsInRole("admin"))
            {
                IEnumerable<Message> messages = db.Messages;
                ViewBag.Feedback = messages;
            }

            return View();
        }


        [Authorize(Roles ="user")]
        [HttpPost]
        public ActionResult FeedBack(Message message)
        {
            message.dateTime = DateTime.Now;
            db.Messages.Add(message);
            db.SaveChanges();
            string mes = "SUCCESS";
            return Json(new { Message = mes, JsonRequestBehavior.AllowGet });
        }

        public ActionResult DeleteFeedback(int id)
        {
            if (id == -1)
                db.Database.ExecuteSqlCommand("truncate table [messages]");
            else
            {
                Message message = new Message
                {
                    Id = id
                };
                db.Messages.Attach(message);
                db.Messages.Remove(message);
            }
            db.SaveChanges();
            IEnumerable<Message> messages = db.Messages;
            ViewBag.Feedback = messages;
            return View("FeedBack");
        }
    }
}