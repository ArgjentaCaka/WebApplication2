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
    public class StaffController : Controller
    {
        
        private WebEntities db = new WebEntities();




        // GET: staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(Details);
        }

        // GET: staff/Create
        public ActionResult Create()
        {
            return View(Create);
        }

        private ActionResult View(Func<int?, ActionResult> details)
        {
            throw new NotImplementedException();
        }

        // POST: staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,emri,mbiemri,pozita")] staff staff)
        {
            if (ModelState.IsValid)
            {

                db.Staff.Add(staff);
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
            List<Models.StaffModel> staff = new List<StaffModel>();
            staff.Add(new StaffModel(1, "Emri", "Mbiemri", "Pozita"));



            return View("Index", staff);
        }

        // GET: staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (staff Edit = db.Staff.Find(id))
            {
                if (Edit == null)
                {
                    return HttpNotFound();
                }
                return View(Edit);
            }
        }

        // POST: staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,emri,mbimeri,pozita")] staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View(staff);
            }
            db.Entry(staff).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET:  staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (service Delete = db.Staff.Find(id))
            {
                if (Delete == null)
                {
                    return HttpNotFound();
                }
                return View(Delete);
            }
        }

        // POST: staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (staff staff = db.Staff.Find(id))
            {
                object p = db.Staff.Delete(staff);
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

    internal class staff
    {
    }

    internal class StaffModel
    {
        private int v1;
        private string v2;
        private string v3;
        private string v4;

        public StaffModel(int v1, string v2, string v3, string v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }
    }
}
    
