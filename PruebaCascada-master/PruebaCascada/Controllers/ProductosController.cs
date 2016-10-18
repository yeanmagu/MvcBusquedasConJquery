using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaCascada.DAL;

namespace PruebaCascada.Controllers
{
    public class ProductosController : Controller
    {
        private PruebaCascadaEntities db = new PruebaCascadaEntities();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Categorias).Include(p => p.Subcategorias);
            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.idcat = new SelectList(db.Categorias, "id", "nombre");
            ViewBag.idsubcat = new SelectList(db.Subcategorias, "id", "nombre");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,idcat,idsubcat")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcat = new SelectList(db.Categorias, "id", "nombre", productos.idcat);
            ViewBag.idsubcat = new SelectList(db.Subcategorias, "id", "nombre", productos.idsubcat);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcat = new SelectList(db.Categorias, "id", "nombre", productos.idcat);
            ViewBag.idsubcat = new SelectList(db.Subcategorias, "id", "nombre", productos.idsubcat);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,idcat,idsubcat")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcat = new SelectList(db.Categorias, "id", "nombre", productos.idcat);
            ViewBag.idsubcat = new SelectList(db.Subcategorias, "id", "nombre", productos.idsubcat);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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

        public ActionResult MostrarSubCategorias(int id)
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            List<Subcategorias> lsSub = (from t in db.Subcategorias
                                         where t.idcat == id
                                         select t).ToList();            

            foreach (var item in lsSub)
            {
                lista.Add(new SelectListItem { Text = item.nombre, Value = item.id.ToString() });
            }

            return Json(new SelectList(lista, "Value", "Text"));

        }

    }
}
