using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("gru_Grupo")]
    public partial class GruGrupo
    {
        public GruGrupo()
        {
            CalCalendarios = new HashSet<CalCalendario>();
            ChgChatGrupos = new HashSet<ChgChatGrupo>();
            EncEncuesta = new HashSet<EncEncuestum>();
            PosPosts = new HashSet<PosPost>();
            UsgUsuarioGrupos = new HashSet<UsgUsuarioGrupo>();
            Usus = new HashSet<UsuUsuario>();
        }

        [Key]
        [Column("gru_Id")]
        public int GruId { get; set; }
        [Column("gru_Imagen")]
        [StringLength(500)]
        [Unicode(false)]
        public string GruImagen { get; set; } = null!;
        [Column("gru_Nombre")]
        [StringLength(500)]
        [Unicode(false)]
        public string GruNombre { get; set; } = null!;
        [Column("gru_Descripcion")]
        [StringLength(2000)]
        [Unicode(false)]
        public string? GruDescripcion { get; set; }
        [Column("gru_Privado")]
        public bool GruPrivado { get; set; }
        [Column("usu_Id")]
        public int UsuId { get; set; }

        [ForeignKey(nameof(UsuId))]
        [InverseProperty(nameof(UsuUsuario.GruGrupos))]
        public virtual UsuUsuario Usu { get; set; } = null!;
        [InverseProperty(nameof(CalCalendario.Gru))]
        public virtual ICollection<CalCalendario> CalCalendarios { get; set; }
        [InverseProperty(nameof(ChgChatGrupo.Gru))]
        public virtual ICollection<ChgChatGrupo> ChgChatGrupos { get; set; }
        [InverseProperty(nameof(EncEncuestum.Gru))]
        public virtual ICollection<EncEncuestum> EncEncuesta { get; set; }
        [InverseProperty(nameof(PosPost.Gru))]
        public virtual ICollection<PosPost> PosPosts { get; set; }
        [InverseProperty(nameof(UsgUsuarioGrupo.Gru))]
        public virtual ICollection<UsgUsuarioGrupo> UsgUsuarioGrupos { get; set; }

        [ForeignKey("GruId")]
        [InverseProperty(nameof(UsuUsuario.Grus))]
        public virtual ICollection<UsuUsuario> Usus { get; set; }
    }
}
