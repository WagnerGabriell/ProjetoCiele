using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoCiele.Entidades;

namespace ProjetoCiele
{
    public class Contexto: DbContext
    {
        public Contexto (DbContextOptions<Contexto> options) : base(options){}
        public DbSet<Produtos> PRODUTOS { get; set; }
        public DbSet<Usuario> USUARIOS { get; set; }
        public DbSet<Permisao> PERMISAO { get; set; }
        public DbSet<PermissaoUsuario> PERMISSAO_USUARIO { get; set; }

    }
}
