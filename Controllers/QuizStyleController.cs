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
    public class QuizStyleController : Controller
    {
        RateContext manager = new RateContext();

        // GET: QuizStyle
        public ActionResult Index()
        {
            var model = manager.QuizStyles;
            return View(model);
        }

        // GET: QuizStyle/Details/5
        public ActionResult Details(int id)
        {
            var model = manager.QuizStyles.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        // GET: QuizStyle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuizStyle/Create
        [HttpPost]
        public ActionResult Create(QuizStyle quizStyle)
        {
            if (ModelState.IsValid)
            {
                manager.QuizStyles.Add(quizStyle);
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: QuizStyle/Edit/5
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                QuizStyle quizStyle = manager.QuizStyles.Find(id);

                ViewBag.QuizStyle = quizStyle;
                return View();
            }
            return HttpNotFound();
        }

        // POST: QuizStyle/Edit/5
        [HttpPost]
        public ActionResult Edit(QuizStyle quizStyle)
        {
            if (ModelState.IsValid)
            {
                manager.Entry(quizStyle).State = EntityState.Modified;
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: QuizStyle/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = manager.QuizStyles.Find(id);
            return View(model);
        }

        // POST: QuizStyle/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                QuizStyle quizStyle = manager.QuizStyles.Find(id);

                if (quizStyle != null)
                {
                    manager.QuizStyles.Remove(quizStyle);
                    manager.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
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
