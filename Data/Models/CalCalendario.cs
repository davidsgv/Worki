using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("cal_Calendario")]
    public partial class CalCalendario
    {
        [Key]
        [Column("cal_Id")]
        public int CalId { get; set; }
        [Column("cal_Fecha", TypeName = "datetime")]
        public DateTime CalFecha { get; set; }
        [Column("cal_Descripcion")]
        [StringLength(1000)]
        [Unicode(false)]
        public string CalDescripcion { get; set; } = null!;
        [Column("gru_Id")]
        public int GruId { get; set; }

        [ForeignKey(nameof(GruId))]
        [InverseProperty(nameof(GruGrupo.CalCalendarios))]
        public virtual GruGrupo Gru { get; set; } = null!;
    }
}
