using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjemploPersonas.Models;
using EjemploPersonas.DAL;

namespace EjemploPersonas.Web.Controllers
{
    public class ClienteController : Controller
    {
        private IRepository<Cliente> respositorycliente;
        private IRepository<Ciudad> respositoryciudad;

        public ClienteController(IRepository<Cliente> respositorycliente, IRepository<Ciudad> respositoryciudad)
        {
            this.respositorycliente = respositorycliente;
            this.respositoryciudad = respositoryciudad;
        }


        // GET: Cliente
        public ActionResult Index()
        {
            return View(respositorycliente.FindAll());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            Cliente cliente = respositorycliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.Ciudadid = new SelectList(respositoryciudad.FindAll(), "Id", "Nombre");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,FechaNacimiento,Ciudadid")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                respositorycliente.Create(cliente);
                respositorycliente.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ciudadid = new SelectList(respositoryciudad.FindAll(), "Id", "Nombre", cliente.Ciudadid);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = respositorycliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ciudadid = new SelectList(respositoryciudad.FindAll(), "Id", "Nombre", cliente.Ciudadid);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,FechaNacimiento,Ciudadid")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                respositorycliente.Update(cliente);
                respositorycliente.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ciudadid = new SelectList(respositoryciudad.FindAll(), "Id", "Nombre", cliente.Ciudadid);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            Cliente cliente = respositorycliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = respositorycliente.Find(id);
            respositorycliente.Delete(cliente);
            respositorycliente.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
