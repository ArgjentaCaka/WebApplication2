using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ScheduleController : Controller
    {
        private WebEntities db = new WebEntities();

// GET: Schedule
public ActionResult Index()
{
    return View(db.schedule.ToList());
}

// GET: Schedule/Details/5
public ActionResult Details(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    schedule schedule = db.schedule.Find(id);
    if (schedule == null)
    {
        return HttpNotFound();
    }
    return View(Schedule);
}

// GET: Schedule/Create
public ActionResult Create()
{
    return View();
}

// POST: Schedule/Create
// To protect from overposting attacks, enable the specific properties you want to bind to, for 
// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "id,time,lesson")] Schedule schedule)
{
    if (ModelState.IsValid)
    {
        db.schedule.Add(schedule);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(schedule);
}
        public ActionResult Index()
        {
            List<ScheduleModel> schedules = new List<ScheduleModel>();
            schedules.Add(new ScheduleModel(0, "13:45-15:00", "Biology"));
            schedules.Add(new ScheduleModel(1, "14:45-16:00", "English"));


            return View("Index", schedules)
        }

// GET: Schedule/Edit/5
public ActionResult Edit(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Schedule  schedule = db.schedule.Find(id);
    if (schedule == null)
    {
        return HttpNotFound();
    }
    return View(schedule);
}

// POST: Schedule/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to, for 
// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit([Bind(Include = "id,time,lesson")] schedule schedule)
{
    if (ModelState.IsValid)
    {
        db.Entry(schedule).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    return View(schedule);
}

// GET: Schedule/Delete/5
public ActionResult Delete(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    schedule schedule = db.schedule.Find(id);
    if (schedule == null)
    {
        return HttpNotFound();
    }
    return View(schedule);
}

// POST: Schedule/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public ActionResult DeleteConfirmed(int id)
{
    schedule schedule = db.schedule.Find(id);
    db.schedule.Remove(schedule);
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

    internal class ScheduleModel
    {
        public ScheduleModel(int v1, string v2, string v3)
        {
        }
    }
}
