using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("ree_RespuestaEncuesta")]
    public partial class ReeRespuestaEncuestum
    {
        [Key]
        [Column("ree_Id")]
        public int ReeId { get; set; }
        [Column("usu_Id")]
        public int UsuId { get; set; }
        [Column("ope_Id")]
        public int OpeId { get; set; }

        [ForeignKey(nameof(OpeId))]
        [InverseProperty(nameof(OpeOpcionEncuestum.ReeRespuestaEncuesta))]
        public virtual OpeOpcionEncuestum Ope { get; set; } = null!;
        [ForeignKey(nameof(UsuId))]
        [InverseProperty(nameof(UsuUsuario.ReeRespuestaEncuesta))]
        public virtual UsuUsuario Usu { get; set; } = null!;
    }
}
