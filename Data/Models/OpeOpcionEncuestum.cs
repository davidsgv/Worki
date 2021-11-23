using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("ope_OpcionEncuesta")]
    public partial class OpeOpcionEncuestum
    {
        public OpeOpcionEncuestum()
        {
            ReeRespuestaEncuesta = new HashSet<ReeRespuestaEncuestum>();
        }

        [Key]
        [Column("ope_Id")]
        public int OpeId { get; set; }
        [Column("ope_Respuesta")]
        [StringLength(100)]
        [Unicode(false)]
        public string OpeRespuesta { get; set; } = null!;
        [Column("ope_EsCorrecta")]
        public bool OpeEsCorrecta { get; set; }
        [Column("pre_Id")]
        public int PreId { get; set; }

        [ForeignKey(nameof(PreId))]
        [InverseProperty(nameof(PrePreguntaEncuestum.OpeOpcionEncuesta))]
        public virtual PrePreguntaEncuestum Pre { get; set; } = null!;
        [InverseProperty(nameof(ReeRespuestaEncuestum.Ope))]
        public virtual ICollection<ReeRespuestaEncuestum> ReeRespuestaEncuesta { get; set; }
    }
}
