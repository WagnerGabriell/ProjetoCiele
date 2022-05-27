using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoCiele.Entidades;

namespace ProjetoCiele.Controllers
{
    public class PermissaoUsuarioController : Controller
    {
        private readonly Contexto db;
        public PermissaoUsuarioController (Contexto contexto)
        {
            db = contexto;
        }
        [HttpGet("[controller]/[action]{Usuariosid}/{Permissaoid}")]
        public IActionResult Adcionar(int Usuarioid, int Permissaoid)
        {
            PermissaoUsuario novo = new PermissaoUsuario();
            novo.Usuarioid = Usuarioid;
            novo.Permissaoid = Permissaoid;
            db.PERMISSAO_USUARIO.Add(novo);
            db.SaveChanges();
            return Redirect("/Usuarios");
        }
    }
}
