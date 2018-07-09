using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjemploPersonas.DAL;
using EjemploPersonas.Models;

namespace EjemploPersonas.Web.Controllers
{
    public class CiudadController : Controller
    {
        private IRepository<Ciudad> respositoryciudad;
        private IRepository<Departamento> respositorydepartamento;

        public CiudadController(IRepository<Ciudad> respositoryciudad, IRepository<Departamento> respositorydepartamento)
        {
            this.respositoryciudad = respositoryciudad;
            this.respositorydepartamento = respositorydepartamento;
        }

        // GET: Ciudad
        public ActionResult Index()
        {
            return View(respositoryciudad.FindAll());
        }

        // GET: Ciudad/Details/5
        public ActionResult Details(int id)
        {
            Ciudad ciudad = respositoryciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: Ciudad/Create
        public ActionResult Create()
        {
            ViewBag.Departamentoid = new SelectList(respositorydepartamento.FindAll(), "Id", "Nombre");
            return View();
        }

        // POST: Ciudad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Departamentoid")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                respositoryciudad.Create(ciudad);
                respositoryciudad.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departamentoid = new SelectList(respositorydepartamento.FindAll(), "Id", "Nombre", ciudad.Departamentoid);
            return View(ciudad);
        }

        // GET: Ciudad/Edit/5
        public ActionResult Edit(int id)
        {
            Ciudad ciudad = respositoryciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.Departamentoid = new SelectList(respositorydepartamento.FindAll(), "Id", "Nombre", ciudad.Departamentoid);
            return View(ciudad);
        }

        // POST: Ciudad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Departamentoid")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                respositoryciudad.Update(ciudad);
                respositoryciudad.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departamentoid = new SelectList(respositorydepartamento.FindAll(), "Id", "Nombre", ciudad.Departamentoid);
            return View(ciudad);
        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(int id)
        {
            Ciudad ciudad = respositoryciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ciudad ciudad = respositoryciudad.Find(id);
            respositoryciudad.Delete(ciudad);
            respositoryciudad.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
