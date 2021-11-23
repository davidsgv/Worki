using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("com_Comentario")]
    public partial class ComComentario
    {
        [Key]
        [Column("com_Id")]
        public int ComId { get; set; }
        [Column("com_Comentario")]
        [StringLength(1024)]
        [Unicode(false)]
        public string ComComentario1 { get; set; } = null!;
        [Column("com_Fecha", TypeName = "datetime")]
        public DateTime? ComFecha { get; set; }
        [Column("pos_Id")]
        public int PosId { get; set; }

        [ForeignKey(nameof(PosId))]
        [InverseProperty(nameof(PosPost.ComComentarios))]
        public virtual PosPost Pos { get; set; } = null!;
    }
}
