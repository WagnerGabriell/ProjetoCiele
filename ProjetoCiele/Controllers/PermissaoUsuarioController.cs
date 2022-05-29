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
        [HttpGet("[controller]/[action]/{UsuariosId}/{PermissaoId}")]
        public IActionResult Adicionar(int UsuarioId, int PermissaoId)
        {
            PermissaoUsuario novo = new PermissaoUsuario();
            novo.UsuarioId = UsuarioId;
            novo.Permissaoid = PermissaoId;
            db.PERMISSAO_USUARIO.Add(novo);
            db.SaveChanges();
            return Redirect("/Usuarios");
        }
    }
}
