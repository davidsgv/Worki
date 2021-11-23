using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("cpe_ConfiguracionesPerfil")]
    public partial class CpeConfiguracionesPerfil
    {
        [Key]
        [Column("per_Id")]
        public int PerId { get; set; }
        [Key]
        [Column("con_Id")]
        public int ConId { get; set; }
        [Column("cpe_Valor")]
        public bool CpeValor { get; set; }

        [ForeignKey(nameof(ConId))]
        [InverseProperty(nameof(ConConfiguracione.CpeConfiguracionesPerfils))]
        public virtual ConConfiguracione Con { get; set; } = null!;
        [ForeignKey(nameof(PerId))]
        [InverseProperty(nameof(PerPerfil.CpeConfiguracionesPerfils))]
        public virtual PerPerfil Per { get; set; } = null!;
    }
}
