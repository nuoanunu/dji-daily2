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
    public class itemsController : Controller
    {
        private ThienNgaDatabaseEntities db = new ThienNgaDatabaseEntities();

        // GET: items
        public async Task<ActionResult> Index()
        {
            var items = db.items.Include(i => i.CustomerType1).Include(i => i.order).Include(i => i.tb_customer).Include(i => i.tb_inventory_name).Include(i => i.tb_product_detail);
            return View(await items.ToListAsync());
        }

        // GET: items/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item item = await db.items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: items/Create
        public ActionResult Create()
        {
            ViewBag.CustomerType = new SelectList(db.CustomerTypes, "id", "GroupName");
            ViewBag.orderID = new SelectList(db.orders, "id", "MaBill");
            ViewBag.customerID = new SelectList(db.tb_customer, "id", "customerName");
            ViewBag.inventoryID = new SelectList(db.tb_inventory_name, "id", "InventoryName");
            ViewBag.productDetailID = new SelectList(db.tb_product_detail, "id", "producFactoryID");
            return View();
        }

        // POST: items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,productID,productDetailID,inventoryID,customerID,DateOfSold,orderID,CustomerType,warrantyAvailable,tempname,Verified")] item item)
        {
            if (ModelState.IsValid)
            {
                db.items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerType = new SelectList(db.CustomerTypes, "id", "GroupName", item.CustomerType);
            ViewBag.orderID = new SelectList(db.orders, "id", "MaBill", item.orderID);
            ViewBag.customerID = new SelectList(db.tb_customer, "id", "customerName", item.customerID);
            ViewBag.inventoryID = new SelectList(db.tb_inventory_name, "id", "InventoryName", item.inventoryID);
            ViewBag.productDetailID = new SelectList(db.tb_product_detail, "id", "producFactoryID", item.productDetailID);
            return View(item);
        }

        // GET: items/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item item = await db.items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerType = new SelectList(db.CustomerTypes, "id", "GroupName", item.CustomerType);
            ViewBag.orderID = new SelectList(db.orders, "id", "MaBill", item.orderID);
            ViewBag.customerID = new SelectList(db.tb_customer, "id", "customerName", item.customerID);
            ViewBag.inventoryID = new SelectList(db.tb_inventory_name, "id", "InventoryName", item.inventoryID);
            ViewBag.productDetailID = new SelectList(db.tb_product_detail, "id", "producFactoryID", item.productDetailID);
            return View(item);
        }

        // POST: items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,productID,productDetailID,inventoryID,customerID,DateOfSold,orderID,CustomerType,warrantyAvailable,tempname,Verified")] item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerType = new SelectList(db.CustomerTypes, "id", "GroupName", item.CustomerType);
            ViewBag.orderID = new SelectList(db.orders, "id", "MaBill", item.orderID);
            ViewBag.customerID = new SelectList(db.tb_customer, "id", "customerName", item.customerID);
            ViewBag.inventoryID = new SelectList(db.tb_inventory_name, "id", "InventoryName", item.inventoryID);
            ViewBag.productDetailID = new SelectList(db.tb_product_detail, "id", "producFactoryID", item.productDetailID);
            return View(item);
        }

        // GET: items/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            item item = await db.items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            item item = await db.items.FindAsync(id);
            db.items.Remove(item);
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
