using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("pos_Post")]
    public partial class PosPost
    {
        public PosPost()
        {
            AdjAdjuntos = new HashSet<AdjAdjunto>();
            ComComentarios = new HashSet<ComComentario>();
            CopCompartirs = new HashSet<CopCompartir>();
            DenDenuncia = new HashSet<DenDenuncium>();
            Usus = new HashSet<UsuUsuario>();
        }

        [Key]
        [Column("pos_Id")]
        public int PosId { get; set; }
        [Column("per_Id")]
        public int? PerId { get; set; }
        [Column("pos_Fecha", TypeName = "datetime")]
        public DateTime PosFecha { get; set; }
        [Column("pos_Contenido")]
        [Unicode(false)]
        public string PosContenido { get; set; } = null!;
        [Column("gru_Id")]
        public int? GruId { get; set; }
        [Column("gru_EsDiscusion")]
        public bool GruEsDiscusion { get; set; }
        [Column("gru_EsImportante")]
        public bool GruEsImportante { get; set; }

        [ForeignKey(nameof(GruId))]
        [InverseProperty(nameof(GruGrupo.PosPosts))]
        public virtual GruGrupo? Gru { get; set; }
        [ForeignKey(nameof(PerId))]
        [InverseProperty(nameof(PerPerfil.PosPosts))]
        public virtual PerPerfil? Per { get; set; }
        [InverseProperty(nameof(AdjAdjunto.Pos))]
        public virtual ICollection<AdjAdjunto> AdjAdjuntos { get; set; }
        [InverseProperty(nameof(ComComentario.Pos))]
        public virtual ICollection<ComComentario> ComComentarios { get; set; }
        [InverseProperty(nameof(CopCompartir.Pos))]
        public virtual ICollection<CopCompartir> CopCompartirs { get; set; }
        [InverseProperty(nameof(DenDenuncium.Pos))]
        public virtual ICollection<DenDenuncium> DenDenuncia { get; set; }

        [ForeignKey("PosId")]
        [InverseProperty(nameof(UsuUsuario.Pos))]
        public virtual ICollection<UsuUsuario> Usus { get; set; }
    }
}
