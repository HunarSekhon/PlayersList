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
        private PlayersDBEntities db = new PlayersDBEntities();
        public ActionResult Index()
        {
            return View(db.Tables.ToList());
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

                db.Tables.Add(playerToCreate);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
          
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var playerToEdit = (from p in db.Tables
                                where p.Id == id
                                select p).First();
            return View(playerToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Table playerToEdit)
        {
           
            {
                var originalPlayer = (from p in db.Tables
                                      where p.Id == playerToEdit.Id
                                      select p).First();

                if (!ModelState.IsValid)
                    return View(originalPlayer);
                db.Entry(originalPlayer).CurrentValues.SetValues(playerToEdit);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var playerToDelete = (from p in db.Tables
                                  where p.Id == id
                                  select p).First();
            return View(playerToDelete);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string confirmButton)
        {
            
            {
                var playerDelete = (from p in db.Tables
                                      where p.Id == id
                                      select p).First();
                db.Tables.Remove(playerDelete);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
        }
    }
}
