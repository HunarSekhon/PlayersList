using Players.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Players.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private PlayersDBEntities _db = new PlayersDBEntities();
        public ActionResult Index()
        {
            return View(_db.Tables.ToList());
        }

       

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")] Table playerToCreate)
        {
          
            {
                if (!ModelState.IsValid)
                    return View();

                _db.Tables.Add(playerToCreate);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
          
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var playerToEdit = (from p in _db.Tables
                                where p.Id == id
                                select p).First();
            return View(playerToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Table playerToEdit)
        {
           
            {
                var originalPlayer = (from p in _db.Tables
                                      where p.Id == playerToEdit.Id
                                      select p).First();

                if (!ModelState.IsValid)
                    return View(originalPlayer);
                _db.Entry(originalPlayer).CurrentValues.SetValues(playerToEdit);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var playerToDelete = (from p in _db.Tables
                                  where p.Id == id
                                  select p).First();
            return View(playerToDelete);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string confirmButton)
        {
            
            {
                var playerDelete = (from p in _db.Tables
                                      where p.Id == id
                                      select p).First();
                _db.Tables.Remove(playerDelete);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            
        }
    }
}
