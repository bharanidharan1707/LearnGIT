using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ba_Jet_App;

namespace Ba_Jet_App.Controllers
{
    public class expensedetsController : Controller
    {
        private DB_PrepsEntities db = new DB_PrepsEntities();

        // GET: expensedets
        public ActionResult Index()
        {
            var expensedets = db.expensedets.Include(e => e.shareholder);
            return View(expensedets.ToList());
        }

        // GET: expensedets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expensedet expensedet = db.expensedets.Find(id);
            if (expensedet == null)
            {
                return HttpNotFound();
            }
            return View(expensedet);
        }

        // GET: expensedets/Create
        public ActionResult Create()
        {
            ViewBag.exp_spentby = new SelectList(db.shareholders, "id", "name");
            return View();
        }

        // POST: expensedets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "exp_id,exp_Catg,exp_for,exp_amount,exp_spentby")] expensedet expensedet)
        {
            if (ModelState.IsValid)
            {
                db.expensedets.Add(expensedet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.exp_spentby = new SelectList(db.shareholders, "id", "name", expensedet.exp_spentby);
            return View(expensedet);
        }

        // GET: expensedets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expensedet expensedet = db.expensedets.Find(id);
            if (expensedet == null)
            {
                return HttpNotFound();
            }
            ViewBag.exp_spentby = new SelectList(db.shareholders, "id", "name", expensedet.exp_spentby);
            return View(expensedet);
        }

        // POST: expensedets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "exp_id,exp_Catg,exp_for,exp_amount,exp_spentby")] expensedet expensedet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expensedet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.exp_spentby = new SelectList(db.shareholders, "id", "name", expensedet.exp_spentby);
            return View(expensedet);
        }

        // GET: expensedets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expensedet expensedet = db.expensedets.Find(id);
            if (expensedet == null)
            {
                return HttpNotFound();
            }
            return View(expensedet);
        }

        // POST: expensedets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            expensedet expensedet = db.expensedets.Find(id);
            db.expensedets.Remove(expensedet);
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
