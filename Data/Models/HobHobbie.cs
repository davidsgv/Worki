using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("hob_Hobbie")]
    [Index(nameof(HobNombre), Name = "unique_hob_Nombre", IsUnique = true)]
    public partial class HobHobbie
    {
        public HobHobbie()
        {
            Pers = new HashSet<PerPerfil>();
        }

        [Key]
        [Column("hob_Id")]
        public int HobId { get; set; }
        [Column("hob_Nombre")]
        [StringLength(500)]
        [Unicode(false)]
        public string HobNombre { get; set; } = null!;

        [ForeignKey("HobId")]
        [InverseProperty(nameof(PerPerfil.Hobs))]
        public virtual ICollection<PerPerfil> Pers { get; set; }
    }
}
