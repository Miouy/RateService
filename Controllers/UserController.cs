using rateservice.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rateservice.Controllers
{
    [Authorize(Users = "admin@admin.com")]
    public class UserController : Controller
    {
        RateContext manager = new RateContext();
        
        // GET: User
        public ActionResult Index()
        {
            var model = manager.Users;
            return View(model);
        }

        public ActionResult ViewAll()
        {
            var model = manager.Users;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                manager.Users.Add(user);
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            User user = manager.Users.Find(id);
            if (user != null)
            {
                manager.Users.Remove(user);
                manager.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                User user = manager.Users.Find(id);

                ViewBag.User = user;
                return View();
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                manager.Entry(user).State = EntityState.Modified;
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = manager.Users.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (manager != null)
            {
                manager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}