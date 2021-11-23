using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("pre_PreguntaEncuesta")]
    public partial class PrePreguntaEncuestum
    {
        public PrePreguntaEncuestum()
        {
            OpeOpcionEncuesta = new HashSet<OpeOpcionEncuestum>();
        }

        [Key]
        [Column("pre_Id")]
        public int PreId { get; set; }
        [Column("pre_Pregunta")]
        [StringLength(100)]
        [Unicode(false)]
        public string PrePregunta { get; set; } = null!;
        [Column("pre_CantidadOpciones")]
        public int PreCantidadOpciones { get; set; }
        [Column("pre_FechaVencimiento", TypeName = "datetime")]
        public DateTime PreFechaVencimiento { get; set; }
        [Column("enc_Id")]
        public int EncId { get; set; }

        [ForeignKey(nameof(EncId))]
        [InverseProperty(nameof(EncEncuestum.PrePreguntaEncuesta))]
        public virtual EncEncuestum Enc { get; set; } = null!;
        [InverseProperty(nameof(OpeOpcionEncuestum.Pre))]
        public virtual ICollection<OpeOpcionEncuestum> OpeOpcionEncuesta { get; set; }
    }
}
