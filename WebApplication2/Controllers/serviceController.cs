using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class service : Controller
    {
        private WebEntities db = new WebEntities ();



        // GET: service/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service service = db.service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(Details);
        }

        // GET: service/Create
        public ActionResult Create()
        {
            return View(Create);
        }

        private ActionResult View(Func<int?, ActionResult> details)
        {
            throw new NotImplementedException();
        }

        // POST: service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,announcement,payment")] service service)
        {
            if (ModelState.IsValid)
            {

                db.service.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Create);
        }

        private ActionResult Create(int? arg)
        {
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {
            List<Models.serviceModel> service = new List<serviceModel>();
            service.Add(new serviceModel(0, "100", "Afati i provimeve"));
            


            return View("Index", service);
        }

        // GET: service/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (service Edit = db.service.Find(id))
            {
                if (Edit == null)
                {
                    return HttpNotFound();
                }
                return View(Edit);
            }
        }

        // POST: service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,announcement,payment")] service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            db.Entry(service).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (service Delete = db.service.Find(id))
            {
                if (Delete == null)
                {
                    return HttpNotFound();
                }
                return View(Delete);
            }
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (service service = db.service.Find(id))
            {
                object p = db.service.Delete(service);
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
