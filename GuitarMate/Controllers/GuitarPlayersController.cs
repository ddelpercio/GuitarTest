using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GuitarMate.Models;

namespace GuitarMate.Controllers
{
    public class GuitarPlayersController : Controller
    {
        private GuitarPlayerDBContext db = new GuitarPlayerDBContext();

        // GET: GuitarPlayers
        public ActionResult Index(string searchString, string city)
        {

            var players = from m in db.GuitarPlayers select m;

            if(!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(s => s.Instrument.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(city))
            {
                players = players.Where(x => x.Location == city);
            }


            return View(players);
        }

        // GET: GuitarPlayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuitarPlayer guitarPlayer = db.GuitarPlayers.Find(id);
            if (guitarPlayer == null)
            {
                return HttpNotFound();
            }
            return View(guitarPlayer);
        }

        [Authorize]
        // GET: GuitarPlayers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuitarPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlayerName,Location,Instrument,AdDescription")] GuitarPlayer guitarPlayer)
        {
            if (ModelState.IsValid)
            {
                db.GuitarPlayers.Add(guitarPlayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guitarPlayer);
        }

        // GET: GuitarPlayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuitarPlayer guitarPlayer = db.GuitarPlayers.Find(id);
            if (guitarPlayer == null)
            {
                return HttpNotFound();
            }
            return View(guitarPlayer);
        }

        // POST: GuitarPlayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlayerName,Location,Instrument,AdDescription")] GuitarPlayer guitarPlayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guitarPlayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guitarPlayer);
        }

        // GET: GuitarPlayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuitarPlayer guitarPlayer = db.GuitarPlayers.Find(id);
            if (guitarPlayer == null)
            {
                return HttpNotFound();
            }
            return View(guitarPlayer);
        }

        // POST: GuitarPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuitarPlayer guitarPlayer = db.GuitarPlayers.Find(id);
            db.GuitarPlayers.Remove(guitarPlayer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
