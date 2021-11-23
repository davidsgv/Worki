using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("gup_GustosProfesionales")]
    [Index(nameof(GupNombre), Name = "unique_gup_Nombre", IsUnique = true)]
    public partial class GupGustosProfesionale
    {
        public GupGustosProfesionale()
        {
            Pers = new HashSet<PerPerfil>();
        }

        [Key]
        [Column("gup_Id")]
        public int GupId { get; set; }
        [Column("gup_Nombre")]
        [StringLength(1000)]
        [Unicode(false)]
        public string GupNombre { get; set; } = null!;

        [ForeignKey("GupId")]
        [InverseProperty(nameof(PerPerfil.Gups))]
        public virtual ICollection<PerPerfil> Pers { get; set; }
    }
}
