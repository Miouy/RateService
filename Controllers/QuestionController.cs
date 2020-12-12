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
    public class QuestionController : Controller
    {
        RateContext manager = new RateContext();

        // GET: Question
        public ActionResult Index()
        {
            var model = manager.Questions;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList ownerUserId = new SelectList(manager.Users, "Id", "LastName");
            ViewBag.OwnerUsers = ownerUserId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                manager.Questions.Add(question);
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Question question = manager.Questions.Find(id);
            
            if (question != null)
            {
                manager.Questions.Remove(question);
                manager.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                Question question = manager.Questions.Find(id);
                SelectList ownerUserId = new SelectList(manager.Users, "Id", "LastName");
                ViewBag.OwnerUsers = ownerUserId;

                ViewBag.Question = question;
                return View(question);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                manager.Entry(question).State = EntityState.Modified;
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            var model = manager.Questions.Find(id);
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
