
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCiele.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public string endereco { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
        public string telefone { get; set; }
    }

}