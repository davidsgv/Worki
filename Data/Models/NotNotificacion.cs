using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("not_Notificacion")]
    public partial class NotNotificacion
    {
        [Key]
        [Column("not_Id")]
        public int NotId { get; set; }
        [Column("not_Fecha", TypeName = "datetime")]
        public DateTime NotFecha { get; set; }
        [Column("not_Tipo")]
        [StringLength(500)]
        [Unicode(false)]
        public string NotTipo { get; set; } = null!;
        [Column("not_Mensaje")]
        [StringLength(2000)]
        [Unicode(false)]
        public string NotMensaje { get; set; } = null!;
        [Column("not_Enviada")]
        public bool NotEnviada { get; set; }
        [Column("usu_Id")]
        public int UsuId { get; set; }

        [ForeignKey(nameof(UsuId))]
        [InverseProperty(nameof(UsuUsuario.NotNotificacions))]
        public virtual UsuUsuario Usu { get; set; } = null!;
    }
}
