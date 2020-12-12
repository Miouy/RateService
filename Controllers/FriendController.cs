using rateservice.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rateservice.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        RateContext manager = new RateContext();

        // GET: Friend
        public ActionResult Index()
        
        {
            List<Friend> friends = manager.Friends.ToList();
            var model = manager.Friends;
            return View(model);
        }

        // GET: Friend/Details/5
        public ActionResult Details(int id)
        {
            var model = manager.Friends.Find(id);
            return View(model);
        }

        // GET: Friend/Create
        public ActionResult Create()
        {
            SelectList ownerUserId = new SelectList(manager.Users, "Id", "LastName");
            ViewBag.OwnerUsers = ownerUserId;
            SelectList friendUserId = new SelectList(manager.Users, "Id", "LastName");
            ViewBag.FriendUsers = ownerUserId;
            return View();
        }

        // POST: Friend/Create
        [HttpPost]
        public ActionResult Create(Friend friends)
        {
            if (ModelState.IsValid)
            {
                manager.Friends.Add(friends);
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Friend/Edit/5
        public ActionResult Edit(int id)
        {
            var model = manager.Friends.Find(id);
            SelectList ownerUserId = new SelectList(manager.Users, "Id", "LastName");
            ViewBag.OwnerUsers = ownerUserId;
            SelectList friendUserId = new SelectList(manager.Users, "Id", "LastName");
            ViewBag.FriendUsers = ownerUserId;
            return View(model);
        }

        // POST: Friend/Edit/5
        [HttpPost]
        public ActionResult Edit(Friend friends)
        {
            if (ModelState.IsValid)
            {
                manager.Entry(friends).State = EntityState.Modified;
                manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Friend/Delete/5
        public ActionResult Delete(int id)
        {
            var model = manager.Friends.Find(id);
            return View();
        }

        // POST: Friend/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Friend friends = manager.Friends.Find(id);

            if (friends != null)
            {
                manager.Friends.Remove(friends);
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
