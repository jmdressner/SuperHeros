using SuperHeros.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeros.Controllers
{
    public class SuperHeroController : Controller
    {
        // GET: SuperHero
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            
            return View(db.SuperHero.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            SuperHero superHero = new SuperHero();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, Name, AlterEgo, PrimaryAbility, SecondaryAbility, Catchprase")] SuperHero superHero)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                if (ModelState.IsValid)
                {
                    db.SuperHero.Add(superHero);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to create superhero. Please try again.");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var hero = db.SuperHero.Where(h => h.ID == id).First();
            return View(hero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Name, AlterEgo, PrimaryAbility, SecondaryAbility, Catchprase")] SuperHero superHero)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(superHero).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again.");
            }
            return View();
        }
    }
}