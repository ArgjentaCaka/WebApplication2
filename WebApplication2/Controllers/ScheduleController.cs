using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class schedule : Controller
    {
        private WebEntities db = new WebEntities();
        



        // GET: Schedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schedule Schedule = db.Schedule.Find(id);
            if (Schedule == null)
            {
                return HttpNotFound();
            }
            return View(Details);
        }

        // GET: Schedule/Create
        public ActionResult Create()
        {
            return View(Create);
        }

        private ActionResult View(Func<int?, ActionResult> details)
        {
            throw new NotImplementedException();
        }

        // POST: Schedule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,time,lesson")] schedule schedule)
        {
            if (ModelState.IsValid)
            {

                db.Schedule.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View (Create);
        }

        private ActionResult Create(int? arg)
        {
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {
            List<ScheduleModel> schedule = new List<ScheduleModel>();
            schedule.Add(new ScheduleModel(0, "13:45-15:00", "Biology"));
            schedule.Add(new ScheduleModel(1, "14:45-16:00", "English"));


            return View("Index", schedule);
        }

        // GET: Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (schedule Edit = db.Schedule.Find(id))
            {
                if (Edit == null)
                {
                    return HttpNotFound();
                }
                return View(Edit);
            }
        }

        // POST: Schedule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,time,lesson")] schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                return View(schedule);
            }
            db.Entry(schedule).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Schedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (schedule Delete = db.Schedule.Find(id))
            {
                if (Delete == null)
                {
                    return HttpNotFound();
                }
                return View(Delete);
            }
        }

        // POST: Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (schedule schedule = db.Schedule.Find(id))
            {
                object p = db.Schedule.Delete(schedule);
            }
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
