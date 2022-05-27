using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCiele.Entidades
{
    public class PermissaoUsuario
    {
        public int id { get; set; }
        public int Usuarioid { get; set; }
        public int Permissaoid { get; set; }
        public Usuario usuario { get; set; }
        public Permisao permissao { get; set; }
    }
}
