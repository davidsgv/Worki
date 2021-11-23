using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("chg_ChatGrupo")]
    public partial class ChgChatGrupo
    {
        [Key]
        [Column("chg_Id")]
        public int ChgId { get; set; }
        [Column("chg_Fecha", TypeName = "datetime")]
        public DateTime ChgFecha { get; set; }
        [Column("chg_Mensaje")]
        [Unicode(false)]
        public string ChgMensaje { get; set; } = null!;
        [Column("gru_Id")]
        public int GruId { get; set; }
        [Column("usu_Id")]
        public int UsuId { get; set; }
        [Column("chg_Link")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? ChgLink { get; set; }
        [Column("chg_GifphyId")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? ChgGifphyId { get; set; }

        [ForeignKey(nameof(GruId))]
        [InverseProperty(nameof(GruGrupo.ChgChatGrupos))]
        public virtual GruGrupo Gru { get; set; } = null!;
        [ForeignKey(nameof(UsuId))]
        [InverseProperty(nameof(UsuUsuario.ChgChatGrupos))]
        public virtual UsuUsuario Usu { get; set; } = null!;
    }
}
