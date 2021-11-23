using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("eti_Etiqueta")]
    public partial class EtiEtiquetum
    {
        public EtiEtiquetum()
        {
            CopCompartirs = new HashSet<CopCompartir>();
        }

        [Key]
        [Column("eti_Id")]
        public int EtiId { get; set; }
        [Column("usu_Id")]
        public int UsuId { get; set; }

        [ForeignKey(nameof(UsuId))]
        [InverseProperty(nameof(UsuUsuario.EtiEtiqueta))]
        public virtual UsuUsuario Usu { get; set; } = null!;
        [InverseProperty(nameof(CopCompartir.Eti))]
        public virtual ICollection<CopCompartir> CopCompartirs { get; set; }
    }
}
