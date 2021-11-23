using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("cop_compartir")]
    public partial class CopCompartir
    {
        [Key]
        [Column("usu_Id")]
        public int UsuId { get; set; }
        [Column("pos_Id")]
        public int PosId { get; set; }
        [Column("eti_Id")]
        public int EtiId { get; set; }

        [ForeignKey(nameof(EtiId))]
        [InverseProperty(nameof(EtiEtiquetum.CopCompartirs))]
        public virtual EtiEtiquetum Eti { get; set; } = null!;
        [ForeignKey(nameof(PosId))]
        [InverseProperty(nameof(PosPost.CopCompartirs))]
        public virtual PosPost Pos { get; set; } = null!;
        [ForeignKey(nameof(UsuId))]
        [InverseProperty(nameof(UsuUsuario.CopCompartir))]
        public virtual UsuUsuario Usu { get; set; } = null!;
    }
}
