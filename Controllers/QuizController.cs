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
    public class QuizController : Controller
    {
        RateContext manager = new RateContext();

        // GET: Quiz
        public ActionResult Index()
        {
            var model = manager.Quizs;
            return View(model);
        }

        // GET: Quiz/Details/5
        public ActionResult Details(int id)
        {
            var model = manager.Quizs.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            SelectList ownerUserId = new SelectList(manager.Users, "Id", "LastName");
            SelectList quizStyleId = new SelectList(manager.QuizStyles, "Id", "QuizStyleName");
            ViewBag.OwnerUsers = ownerUserId;
            ViewBag.QuizStyles = quizStyleId;
            return View();
        }

        // POST: Quiz/Create
        [HttpPost]
        public ActionResult Create(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                manager.Quizs.Add(quiz);
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
            
        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(int id)
        {
            SelectList ownerUserId = new SelectList(manager.Users, "Id", "LastName");
            SelectList quizStyleId = new SelectList(manager.QuizStyles, "Id", "QuizStyleName");
            ViewBag.OwnerUsers = ownerUserId;
            ViewBag.QuizStyles = quizStyleId;
            var model = manager.Quizs.Find(id);
            return View(model);
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        public ActionResult Edit(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                manager.Entry(quiz).State = EntityState.Modified;
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Quiz/Delete/5
        public ActionResult Delete(int id)
        {
            var model = manager.Quizs.Find(id);
            return View(model);
        }

        // POST: Quiz/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Quiz quiz = manager.Quizs.Find(id);

            if (quiz != null)
            {
                manager.Quizs.Remove(quiz);
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
