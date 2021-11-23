using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("per_Perfil")]
    [Index(nameof(UsuId), Name = "Unique_per_usu", IsUnique = true)]
    public partial class PerPerfil
    {
        public PerPerfil()
        {
            CpeConfiguracionesPerfils = new HashSet<CpeConfiguracionesPerfil>();
            PosPosts = new HashSet<PosPost>();
            Gups = new HashSet<GupGustosProfesionale>();
            Hobs = new HashSet<HobHobbie>();
        }

        [Key]
        [Column("per_Id")]
        public int PerId { get; set; }
        [Column("per_Imagen")]
        [StringLength(500)]
        [Unicode(false)]
        public string? PerImagen { get; set; }
        [Column("per_Cargo")]
        [StringLength(500)]
        [Unicode(false)]
        public string? PerCargo { get; set; }
        [Column("per_Estado")]
        [StringLength(150)]
        [Unicode(false)]
        public string? PerEstado { get; set; }
        [Column("usu_Id")]
        public int UsuId { get; set; }

        [ForeignKey(nameof(UsuId))]
        [InverseProperty(nameof(UsuUsuario.PerPerfil))]
        public virtual UsuUsuario Usu { get; set; } = null!;
        [InverseProperty(nameof(CpeConfiguracionesPerfil.Per))]
        public virtual ICollection<CpeConfiguracionesPerfil> CpeConfiguracionesPerfils { get; set; }
        [InverseProperty(nameof(PosPost.Per))]
        public virtual ICollection<PosPost> PosPosts { get; set; }

        [ForeignKey("PerId")]
        [InverseProperty(nameof(GupGustosProfesionale.Pers))]
        public virtual ICollection<GupGustosProfesionale> Gups { get; set; }
        [ForeignKey("PerId")]
        [InverseProperty(nameof(HobHobbie.Pers))]
        public virtual ICollection<HobHobbie> Hobs { get; set; }
    }
}
