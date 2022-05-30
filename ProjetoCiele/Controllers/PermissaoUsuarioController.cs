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
        public IActionResult Adicionar(int UsuariosId, int PermissaoId)
        {
            PermissaoUsuario novo = new PermissaoUsuario();
            novo.UsuarioId = UsuariosId;
            novo.Permissaoid = PermissaoId;
            db.PERMISSAO_USUARIO.Add(novo);
            db.SaveChanges();
            return Redirect("/Usuarios/ListarPermissao/" + UsuariosId);
        }

        public IActionResult Remover(int id)
        {
            PermissaoUsuario item = db.PERMISSAO_USUARIO.Find(id);
            int usuarioId = item.UsuarioId;
            db.PERMISSAO_USUARIO.Remove(item);
            db.SaveChanges();
            return Redirect("/Usuarios/ListarPermissao/" + usuarioId);
        }
    }
}
