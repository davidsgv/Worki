using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("eve_evento")]
    public partial class EveEvento
    {
        public EveEvento()
        {
            Usus = new HashSet<UsuUsuario>();
        }

        [Key]
        [Column("eve_Id")]
        public int EveId { get; set; }
        [Column("eve_Nombre")]
        [StringLength(500)]
        [Unicode(false)]
        public string EveNombre { get; set; } = null!;
        [Column("eve_Descripcion")]
        [StringLength(5000)]
        [Unicode(false)]
        public string EveDescripcion { get; set; } = null!;
        [Column("eve_Fecha", TypeName = "datetime")]
        public DateTime EveFecha { get; set; }
        [Column("eve_Duracion")]
        public int EveDuracion { get; set; }
        [Column("eve_Lugar")]
        [StringLength(500)]
        [Unicode(false)]
        public string EveLugar { get; set; } = null!;
        [Column("usu_Id")]
        public int UsuId { get; set; }

        [ForeignKey(nameof(UsuId))]
        [InverseProperty(nameof(UsuUsuario.EveEventos))]
        public virtual UsuUsuario Usu { get; set; } = null!;

        [ForeignKey("EveId")]
        [InverseProperty(nameof(UsuUsuario.Eves))]
        public virtual ICollection<UsuUsuario> Usus { get; set; }
    }
}
