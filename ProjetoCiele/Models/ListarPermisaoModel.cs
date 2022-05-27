using ProjetoCiele.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCiele.Models
{
    public class ListarPermisaoModel
    {
        public int UsuarioId { get; set; }
        public List<Permisao> TodasPermissoes { get; set; }
        public List<PermissaoUsuario> PermissaoUsuarios { get; set; }
    }
}
