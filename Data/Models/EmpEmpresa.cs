using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("emp_Empresa")]
    public partial class EmpEmpresa
    {
        public EmpEmpresa()
        {
            UsuUsuarios = new HashSet<UsuUsuario>();
        }

        [Key]
        [Column("emp_Id")]
        public int EmpId { get; set; }
        [Column("emp_Nombre")]
        [StringLength(500)]
        [Unicode(false)]
        public string EmpNombre { get; set; } = null!;

        [InverseProperty(nameof(UsuUsuario.Emp))]
        public virtual ICollection<UsuUsuario> UsuUsuarios { get; set; }
    }
}
