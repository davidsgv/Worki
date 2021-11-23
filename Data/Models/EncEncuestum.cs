using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("enc_Encuesta")]
    public partial class EncEncuestum
    {
        public EncEncuestum()
        {
            PrePreguntaEncuesta = new HashSet<PrePreguntaEncuestum>();
        }

        [Key]
        [Column("enc_Id")]
        public int EncId { get; set; }
        [Column("enc_Nombre")]
        [StringLength(45)]
        [Unicode(false)]
        public string EncNombre { get; set; } = null!;
        [Column("gru_Id")]
        public int GruId { get; set; }
        [Column("usu_Id")]
        public int UsuId { get; set; }

        [ForeignKey(nameof(GruId))]
        [InverseProperty(nameof(GruGrupo.EncEncuesta))]
        public virtual GruGrupo Gru { get; set; } = null!;
        [ForeignKey(nameof(UsuId))]
        [InverseProperty(nameof(UsuUsuario.EncEncuesta))]
        public virtual UsuUsuario Usu { get; set; } = null!;
        [InverseProperty(nameof(PrePreguntaEncuestum.Enc))]
        public virtual ICollection<PrePreguntaEncuestum> PrePreguntaEncuesta { get; set; }
    }
}
