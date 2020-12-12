using rateservice.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rateservice.Controllers
{
    [Authorize(Users = "admin@admin.com")]
    public class AnswerController : Controller
    {

        RateContext manager = new RateContext();

        // GET: Answer
        public ActionResult Index()
        {
            var model = manager.Answers;
            return View(model);
        }

        // GET: Answer/Details/5
        public ActionResult Details(int id)
        {
            var model = manager.Answers.Find(id);
            return View(model);
        }

        // GET: Answer/Create
        public ActionResult Create()
        {
            SelectList questions = new SelectList(manager.Questions, "Id", "QuestionTitle");
            ViewBag.questions = questions;
            return View();
        }

        // POST: Answer/Create
        [HttpPost]
        public ActionResult Create(Answer answer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Answers.Add(answer);
                    manager.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Answer/Edit/5
        public ActionResult Edit(int id)
        {
            var model = manager.Answers.Find(id);
            return View(model);
        }

        // POST: Answer/Edit/5
        [HttpPost]
        public ActionResult Edit(Answer answer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Entry(answer).State = EntityState.Modified;
                    manager.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Answer/Delete/5
        public ActionResult Delete(int id)
        {
            var model = manager.Answers.Find(id);
            return View(model);
        }

        // POST: Answer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Answer answer = manager.Answers.Find(id);
                if (answer != null)
                {
                    manager.Answers.Remove(answer);
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
