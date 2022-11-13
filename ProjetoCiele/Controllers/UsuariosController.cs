using ProjetoCiele.Entidades;
using ProjetoCiele.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCiele.Entidades
{
    //[Authorize(AuthenticationSchemes = "CookieAuthentication", Roles ="administrador")]
    public class UsuariosController : Controller
    {
        private readonly Contexto db;

        public UsuariosController(Contexto contexto)
        {
            db = contexto;
        }

        public IActionResult ListarPermissao(int id)
        {
            ListarPermisaoModel model = new ListarPermisaoModel();
            model.TodasPermissoes = db.PERMISAO.ToList();
            model.UsuarioId = id;
            model.PermissaoUsuarios = db.PERMISSAO_USUARIO.Where(a=>a.UsuarioId == id).Include(a => a.permissao).ToList();
            return View(model);
        }

        public IActionResult Index()
        {
            return View(db.USUARIOS.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario dadosTela)
        {
            db.USUARIOS.Add(dadosTela);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }
        public IActionResult Edit(int id)
        {
            return View(db.USUARIOS.Where(a => a.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult Edit(int id, Contexto collection)
        {
            try
            {
                db.Entry(collection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch {
                return View("/");
            }
            
        }
        public IActionResult Delete(int id)
        {
            return View(db.USUARIOS.Where(a => a.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult Delete(int id, Contexto collection)
        {
            try
            {
                Usuario userDelete = db.USUARIOS.Where(a => a.Id == id).FirstOrDefault();
                db.USUARIOS.Remove(userDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("/");
            }

        }
    }
}