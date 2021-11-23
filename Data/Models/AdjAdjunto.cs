using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("adj_adjuntos")]
    public partial class AdjAdjunto
    {
        [Key]
        [Column("adj_Id")]
        public int AdjId { get; set; }
        [Column("adj_Nombre")]
        [StringLength(200)]
        [Unicode(false)]
        public string AdjNombre { get; set; } = null!;
        [Column("adj_RutaImagen")]
        [StringLength(500)]
        [Unicode(false)]
        public string AdjRutaImagen { get; set; } = null!;
        [Column("adj_Tamano")]
        public int AdjTamano { get; set; }
        [Column("pos_Id")]
        public int PosId { get; set; }

        [ForeignKey(nameof(PosId))]
        [InverseProperty(nameof(PosPost.AdjAdjuntos))]
        public virtual PosPost Pos { get; set; } = null!;
    }
}
