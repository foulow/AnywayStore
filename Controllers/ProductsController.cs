using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnywayStore.Helper;
using AnywayStore.Models;

namespace AnywayStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string category = null)
        {
            var iSession = NHibernateHelper.OpenSession();

            var products = iSession.QueryOver<ClassEntityProducts>().List();

            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Product(int? idProduct)
        {
            var iSession = NHibernateHelper.OpenSession();

            var product = iSession.QueryOver<ClassEntityProducts>().Where(field => field.IdProduct == idProduct).List().FirstOrDefault();

            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            //ViewBag.category_id = new SelectList(db.Categories, "id", "name");
            //ViewBag.user_id = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Products.Add(products);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.category_id = new SelectList(db.Categories, "id", "name", products.category_id);
            //ViewBag.user_id = new SelectList(db.Users, "id", "name", products.user_id);
            return View();
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Products products = db.Products.Find(id);
            //if (products == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.category_id = new SelectList(db.Categories, "id", "name", products.category_id);
            //ViewBag.user_id = new SelectList(db.Users, "id", "name", products.user_id);
            return View();
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(products).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.category_id = new SelectList(db.Categories, "id", "name", products.category_id);
            //ViewBag.user_id = new SelectList(db.Users, "id", "name", products.user_id);
            return View();
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Products products = db.Products.Find(id);
            //if (products == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Products products = db.Products.Find(id);
            //db.Products.Remove(products);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
