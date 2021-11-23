using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("con_configuraciones")]
    [Index(nameof(ConDescripcion), Name = "unique_con_Descripcion", IsUnique = true)]
    [Index(nameof(ConNombre), Name = "unique_con_Nombre", IsUnique = true)]
    public partial class ConConfiguracione
    {
        public ConConfiguracione()
        {
            CpeConfiguracionesPerfils = new HashSet<CpeConfiguracionesPerfil>();
        }

        [Key]
        [Column("con_Id")]
        public int ConId { get; set; }
        [Column("con_Nombre")]
        [StringLength(200)]
        [Unicode(false)]
        public string ConNombre { get; set; } = null!;
        [Column("con_Descripcion")]
        [StringLength(500)]
        [Unicode(false)]
        public string ConDescripcion { get; set; } = null!;

        [InverseProperty(nameof(CpeConfiguracionesPerfil.Con))]
        public virtual ICollection<CpeConfiguracionesPerfil> CpeConfiguracionesPerfils { get; set; }
    }
}
