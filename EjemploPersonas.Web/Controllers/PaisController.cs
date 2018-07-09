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
    public class PaisController : Controller
    {
        private IRepository<Pais> repositorypais;

        public PaisController(IRepository<Pais> repositorypais)
        {
            this.repositorypais = repositorypais;
        }


        // GET: Pais
        public ActionResult Index()
        {
            return View(repositorypais.FindAll());
        }

        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            Pais pais = repositorypais.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                repositorypais.Create(pais);
                repositorypais.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pais);
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            Pais pais = repositorypais.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                repositorypais.Update(pais);
                repositorypais.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pais);
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int id)
        {
            Pais pais = repositorypais.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pais pais = repositorypais.Find(id);
            repositorypais.Delete(pais);
            repositorypais.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
