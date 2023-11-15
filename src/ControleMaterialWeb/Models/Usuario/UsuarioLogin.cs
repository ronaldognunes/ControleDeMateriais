using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleMaterialWeb.Models.Usuario
{
    public class UsuarioLogin
    {
        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "email com formato inválido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [MinLength(6, ErrorMessage = "Senha deve conter 6 dígitos")]
        [MaxLength(10, ErrorMessage = "Senha deve conter até 10 dígitos")]
        public string? Senha { get; set; }
    }
}