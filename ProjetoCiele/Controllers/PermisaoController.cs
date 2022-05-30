using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCiele.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCiele.Controllers
{
    public class PermisaoController : Controller
    {
        // GET: PermisaoController
        private readonly Contexto db;
        public PermisaoController(Contexto contexto)
        {
            db = contexto;
        }
        public ActionResult Index()
        {
            return View(db.PERMISAO.ToList());
        }

        // GET: PermisaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PermisaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PermisaoController/Create
        [HttpPost]
        public ActionResult Create(Permisao dadosTela)
        {
            db.PERMISAO.Add(dadosTela);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: PermisaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PermisaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PermisaoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                db.PERMISAO.Remove(db.PERMISAO.Find(id));
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
