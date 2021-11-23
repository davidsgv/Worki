using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("usg_UsuarioGrupo")]
    public partial class UsgUsuarioGrupo
    {
        [Key]
        [Column("gru_Id")]
        public int GruId { get; set; }
        [Key]
        [Column("usu_Id")]
        public int UsuId { get; set; }
        [Column("usg_EsAdministrador")]
        public bool UsgEsAdministrador { get; set; }

        [ForeignKey(nameof(GruId))]
        [InverseProperty(nameof(GruGrupo.UsgUsuarioGrupos))]
        public virtual GruGrupo Gru { get; set; } = null!;
        [ForeignKey(nameof(GruId))]
        [InverseProperty(nameof(UsuUsuario.UsgUsuarioGrupos))]
        public virtual UsuUsuario GruNavigation { get; set; } = null!;
    }
}
