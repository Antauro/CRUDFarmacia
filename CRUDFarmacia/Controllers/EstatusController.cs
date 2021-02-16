using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDFarmacia.Models;

namespace CRUDFarmacia.Controllers
{
    public class EstatusController : Controller
    {
        // Conexión a la base de datos.
        DBFarmaciaEntities db = new DBFarmaciaEntities();

        // GET: Estatus
        public ActionResult Index()
        {
            return View(db.Estatus.ToList());
        }

        // GET: Estatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estatus/Create
        [HttpPost]
        public ActionResult Create(Estatus estatus)
        {
            try
            {
                db.Estatus.Add(estatus);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estatus/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            return View(db.Estatus.Where(x => x.Id == id).SingleOrDefault());
        }

        // POST: Estatus/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Estatus estatus)
        {
            try
            {
                db.Entry(estatus).State = EntityState.Modified;
                db.SaveChanges();

                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Estatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Estatus estatus = db.Estatus.Find(id);

            return View(estatus);
        }

        // POST: Estatus/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Estatus estatus = db.Estatus.Find(id);
            var empleado = db.Empleado.Where(x => x.Estatus == id).ToList();

            foreach (var item in empleado)
            {
                db.Empleado.Remove(item);
                db.SaveChanges();
            }

            db.Estatus.Remove(estatus);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}