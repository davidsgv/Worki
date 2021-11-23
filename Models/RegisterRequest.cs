using System.ComponentModel.DataAnnotations;
using Worki.Data.Models;

namespace Worki.Models
{
    public class RegisterRequest: UsuUsuario
    {
        [Required, MaxLength(500), Display(Name = "Nombre Empresa")]
        public string? EmpNombre { get; set; }

        [Compare(nameof(UsuCorreo)), Display(Name = "Validar Correo")]
        public string? ValidateEmail { get; set; }
    }
}
