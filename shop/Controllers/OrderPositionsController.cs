using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shop.DataAcess;
using shop.Models;

namespace shop.Controllers
{
    public class OrderPositionsController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: OrderPositions
        public ActionResult Index()
        {
            var orderPositions = db.OrderPositions.Include(o => o.Order).Include(o => o.Product);
            return View(orderPositions.ToList());
        }

        // GET: OrderPositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderPosition orderPosition = db.OrderPositions.Find(id);
            if (orderPosition == null)
            {
                return HttpNotFound();
            }
            return View(orderPosition);
        }

        // GET: OrderPositions/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: OrderPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,OrderId,Count")] OrderPosition orderPosition)
        {
            if (ModelState.IsValid)
            {
                db.OrderPositions.Add(orderPosition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address", orderPosition.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderPosition.ProductId);
            return View(orderPosition);
        }

        // GET: OrderPositions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderPosition orderPosition = db.OrderPositions.Find(id);
            if (orderPosition == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address", orderPosition.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderPosition.ProductId);
            return View(orderPosition);
        }

        // POST: OrderPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,OrderId,Count")] OrderPosition orderPosition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderPosition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address", orderPosition.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orderPosition.ProductId);
            return View(orderPosition);
        }

        // GET: OrderPositions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderPosition orderPosition = db.OrderPositions.Find(id);
            if (orderPosition == null)
            {
                return HttpNotFound();
            }
            return View(orderPosition);
        }

        // POST: OrderPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderPosition orderPosition = db.OrderPositions.Find(id);
            db.OrderPositions.Remove(orderPosition);
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
