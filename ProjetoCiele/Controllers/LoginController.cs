﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using ProjetoCiele.Entidades;

namespace ProjetoCiele.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto db;
        public LoginController(Contexto contexto)
        {
            db = contexto;
        }
        public IActionResult Entrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Entrar(string Email, string senha)
        {
            Entidades.Usuario usuarioLogado =
                db.USUARIOS.Where(a => a.Email == Email
                && a.Senha == senha).FirstOrDefault();
            if (usuarioLogado == null)
            {
                TempData["erro"] = "Usuario e senha invalido";
                return View();
            }

            var claims = new List<Claim>();
            claims.Add(
                new Claim(ClaimTypes.Name, usuarioLogado.Nome));
            claims.Add(
                new Claim(ClaimTypes.Sid, usuarioLogado.Id.ToString()));

            var UserIdentity = new ClaimsIdentity(claims, "Acesso");

            ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);
            await HttpContext.SignInAsync("CookieAuthentication", principal, new AuthenticationProperties());

            return Redirect("/");
        }
        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync("CookieAuthentication");
            ViewData["ReturnUrl"] = "/";
            return Redirect("/Login/Entrar");
        }
    }
}