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
    public class DepartamentoController : Controller
    {
        private IRepository<Departamento> respositorydepartamento;
        private IRepository<Pais> respositorypais;

        public DepartamentoController(IRepository<Departamento> respositorydepartamento, IRepository<Pais> respositorypais)
        {
            this.respositorydepartamento = respositorydepartamento;
            this.respositorypais = respositorypais;
        }


        // GET: Departamento
        public ActionResult Index()
        {
            return View(respositorydepartamento.FindAll());
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int id)
        {
            Departamento departamento = respositorydepartamento.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
            ViewBag.Paisid = new SelectList(respositorypais.FindAll(), "Id", "Nombre");
            return View();
        }

        // POST: Departamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Paisid")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                respositorydepartamento.Create(departamento);
                respositorydepartamento.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Paisid = new SelectList(respositorypais.FindAll(), "Id", "Nombre", departamento.Paisid);
            return View(departamento);
        }

        // GET: Departamento/Edit/5
        public ActionResult Edit(int id)
        {
            Departamento departamento = respositorydepartamento.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Paisid = new SelectList(respositorypais.FindAll(), "Id", "Nombre", departamento.Paisid);
            return View(departamento);
        }

        // POST: Departamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Paisid")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                respositorydepartamento.Update(departamento);
                respositorydepartamento.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Paisid = new SelectList(respositorypais.FindAll(), "Id", "Nombre", departamento.Paisid);
            return View(departamento);
        }

        // GET: Departamento/Delete/5
        public ActionResult Delete(int id)
        {
            Departamento departamento = respositorydepartamento.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamento departamento = respositorydepartamento.Find(id);
            respositorydepartamento.Delete(departamento);
            respositorydepartamento.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
