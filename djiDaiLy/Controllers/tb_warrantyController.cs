using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using djiDaiLy.Models;

namespace djiDaiLy.Controllers
{
    public class tb_warrantyController : Controller
    {
        private ThienNgaDatabaseEntities db = new ThienNgaDatabaseEntities();

        // GET: tb_warranty
        public async Task<ActionResult> Index()
        {
            var tb_warranty = db.tb_warranty.Include(t => t.item);
            return View(await tb_warranty.ToListAsync());
        }

        // GET: tb_warranty/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_warranty tb_warranty = await db.tb_warranty.FindAsync(id);
            if (tb_warranty == null)
            {
                return HttpNotFound();
            }
            return View(tb_warranty);
        }

        // GET: tb_warranty/Create
        public ActionResult Create()
        {
            ViewBag.itemID = new SelectList(db.items, "id", "productID");
            return View();
        }

        // POST: tb_warranty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,warrantyID,itemID,startdate,duration,description,MaChinh,Special")] tb_warranty tb_warranty)
        {
            if (ModelState.IsValid)
            {
                db.tb_warranty.Add(tb_warranty);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.itemID = new SelectList(db.items, "id", "productID", tb_warranty.itemID);
            return View(tb_warranty);
        }

        // GET: tb_warranty/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_warranty tb_warranty = await db.tb_warranty.FindAsync(id);
            if (tb_warranty == null)
            {
                return HttpNotFound();
            }
            ViewBag.itemID = new SelectList(db.items, "id", "productID", tb_warranty.itemID);
            return View(tb_warranty);
        }

        // POST: tb_warranty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,warrantyID,itemID,startdate,duration,description,MaChinh,Special")] tb_warranty tb_warranty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_warranty).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.itemID = new SelectList(db.items, "id", "productID", tb_warranty.itemID);
            return View(tb_warranty);
        }

        // GET: tb_warranty/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_warranty tb_warranty = await db.tb_warranty.FindAsync(id);
            if (tb_warranty == null)
            {
                return HttpNotFound();
            }
            return View(tb_warranty);
        }

        // POST: tb_warranty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_warranty tb_warranty = await db.tb_warranty.FindAsync(id);
            db.tb_warranty.Remove(tb_warranty);
            await db.SaveChangesAsync();
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
