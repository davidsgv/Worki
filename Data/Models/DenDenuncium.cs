using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("den_Denuncia")]
    public partial class DenDenuncium
    {
        [Key]
        [Column("den_Id")]
        public int DenId { get; set; }
        [Column("den_Fecha", TypeName = "datetime")]
        public DateTime DenFecha { get; set; }
        [Column("usu_Id")]
        public int UsuId { get; set; }
        [Column("pos_Id")]
        public int PosId { get; set; }

        [ForeignKey(nameof(PosId))]
        [InverseProperty(nameof(PosPost.DenDenuncia))]
        public virtual PosPost Pos { get; set; } = null!;
        [ForeignKey(nameof(UsuId))]
        [InverseProperty(nameof(UsuUsuario.DenDenuncia))]
        public virtual UsuUsuario Usu { get; set; } = null!;
    }
}
