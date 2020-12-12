using rateservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rateservice.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        RateContext manager = new RateContext();
        public ActionResult Index()
        {
            User user = manager.Users.FirstOrDefault(u=> u.Email == User.Identity.Name);
            ViewBag.CurrentUser = user;
            ViewBag.Age = DateTime.Today.Year - user.BirthDate.Year;
            var questions = manager.Questions;
            ViewBag.Questions = questions;
            return View(); 
        }

        public ActionResult QuestionSearch(string questionTitle="")
        {
            var allquestions = manager.Questions.Where(a =>a.QuestionTitle.Contains(questionTitle)).ToList();
            return PartialView(allquestions);
        }

        public ActionResult AllQuestions()
        {
            var model = manager.Questions;
            return View(model);
        }

        [Authorize]
        public ActionResult Profile()
        {
            User user = manager.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            ViewBag.CurrentUser = user;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult CheckQuestionText(string questionText)
        {
            var result = !(questionText.Length <=3);
            return Json(result, JsonRequestBehavior.AllowGet);
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