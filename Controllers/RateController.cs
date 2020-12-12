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
    public class RateController : Controller
    {
        RateContext manager = new RateContext();

        // GET: Rate
        public ActionResult Index()
        {
            var model = manager.Rates;
            return View(model);
        }

        // GET: Rate/Details/5
        public ActionResult Details(int id)
        {
            var model = manager.Rates.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        // GET: Rate/Create
        public ActionResult Create()
        {
            SelectList ownerUserId = new SelectList(manager.Users, "Id", "LastName");
            SelectList quizChoiseId = new SelectList(manager.QuizChoices, "Id", "QuizChoiceText");
            SelectList quizId = new SelectList(manager.Quizs, "Id", "QuizTitle");
            ViewBag.OwnerUsers = ownerUserId;
            ViewBag.QuizChois = quizChoiseId;
            ViewBag.Quizs = quizId;
            return View();
        }

        // POST: Rate/Create
        [HttpPost]
        public ActionResult Create(Rate rate)
        {
            if (ModelState.IsValid)
            {
                manager.Rates.Add(rate);
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Rate/Edit/5
        public ActionResult Edit(int id)
        {
            var model = manager.Rates.Find(id);
            SelectList ownerUserId = new SelectList(manager.Users, "Id", "LastName");
            SelectList quizChoiseId = new SelectList(manager.QuizChoices, "Id", "QuizChoiceText");
            SelectList quizId = new SelectList(manager.Quizs, "Id", "QuizTitle");
            ViewBag.OwnerUsers = ownerUserId;
            ViewBag.QuizChois = quizChoiseId;
            ViewBag.Quizs = quizId;
            return View(model);
        }

        // POST: Rate/Edit/5
        [HttpPost]
        public ActionResult Edit(Rate rate)
        {
            if (ModelState.IsValid)
            {
                manager.Entry(rate).State = EntityState.Modified;
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Rate/Delete/5
        public ActionResult Delete(int id)
        {
            var model = manager.Rates.Find(id);
            return View(model);
        }

        // POST: Rate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Rate rate = manager.Rates.Find(id);

            if (rate != null)
            {
                manager.Rates.Remove(rate);
                manager.SaveChanges();
            }
            return RedirectToAction("Index");
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
