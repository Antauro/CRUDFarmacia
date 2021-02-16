using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDFarmacia.Models;

namespace CRUDFarmacia.Controllers
{
    public class EmpleadoController : Controller
    {
        // Conexión a la base de datos.
        DBFarmaciaEntities db = new DBFarmaciaEntities();

        // GET: Empleado
        public ActionResult Index()
        {
            List<Empleado> empleados = db.Empleado.ToList();
            List<Estatus> estatus = db.Estatus.ToList();

            var empleado = from em in empleados
                           join es in estatus on em.Estatus equals es.Id

                           select new EmpleadoViewModel
                           {
                               EmpleadoDetails = em,
                               EstatusDetails = es
                           };

            return View(empleado.ToList());
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewData["Estatus"] = new SelectList(db.Estatus.ToList(), "Id", "Nombre");
            return View();
        }

        // POST: Empleado/Create
        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            try
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleado/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewData["Estatus"] = new SelectList(db.Estatus.ToList(), "Id", "Nombre");
            return View(db.Empleado.Where(x => x.Id == id).SingleOrDefault());
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Empleado empleado)
        {
            try
            {
                db.Entry(empleado).State = EntityState.Modified;
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

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Empleado empleado = db.Empleado.Find(id);
            
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
