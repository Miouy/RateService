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
    public class QuizChoiceController : Controller
    {
        RateContext manager = new RateContext();

        // GET: QuizChoice
        public ActionResult Index()
        {
            var model = manager.QuizChoices;
            return View(model);
        }

        // GET: QuizChoice/Details/5
        public ActionResult Details(int id)
        {
            var model = manager.QuizChoices.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        // GET: QuizChoice/Create
        public ActionResult Create()
        {
            SelectList quizId = new SelectList(manager.Quizs, "Id", "QuizTitle");
            ViewBag.Quizs = quizId;
            return View();
        }

        // POST: QuizChoice/Create
        [HttpPost]
        public ActionResult Create(QuizChoice quizChoice)
        {
            if (ModelState.IsValid)
            {
                manager.QuizChoices.Add(quizChoice);
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: QuizChoice/Edit/5
        public ActionResult Edit(int id)
        {
            var model = manager.QuizChoices.Find(id);
            SelectList quizId = new SelectList(manager.Quizs, "Id", "QuizTitle");
            ViewBag.Quizs = quizId;
            return View(model);
        }

        // POST: QuizChoice/Edit/5
        [HttpPost]
        public ActionResult Edit(QuizChoice quizChoice)
        {
            if (ModelState.IsValid)
            {
                manager.Entry(quizChoice).State = EntityState.Modified;
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: QuizChoice/Delete/5
        public ActionResult Delete(int id)
        {
            var model = manager.QuizChoices.Find(id);
            return View(model);
        }

        // POST: QuizChoice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            QuizChoice quizChoice = manager.QuizChoices.Find(id);

            if (quizChoice != null)
            {
                manager.QuizChoices.Remove(quizChoice);
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
