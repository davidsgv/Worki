using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("chu_ChatUsuario")]
    public partial class ChuChatUsuario
    {
        [Key]
        [Column("chu_Id")]
        public int ChuId { get; set; }
        [Column("chu_Fecha", TypeName = "datetime")]
        public DateTime ChuFecha { get; set; }
        [Column("chu_Mensaje")]
        [Unicode(false)]
        public string ChuMensaje { get; set; } = null!;
        [Column("chu_EsLeido")]
        public bool ChuEsLeido { get; set; }
        [Column("usu_IdEnvia")]
        public int UsuIdEnvia { get; set; }
        [Column("usu_IdRecibe")]
        public int UsuIdRecibe { get; set; }
        [Column("chu_Link")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? ChuLink { get; set; }
        [Column("chu_GifphyId")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? ChuGifphyId { get; set; }

        [ForeignKey(nameof(UsuIdEnvia))]
        [InverseProperty(nameof(UsuUsuario.ChuChatUsuarioUsuIdEnviaNavigations))]
        public virtual UsuUsuario UsuIdEnviaNavigation { get; set; } = null!;
        [ForeignKey(nameof(UsuIdRecibe))]
        [InverseProperty(nameof(UsuUsuario.ChuChatUsuarioUsuIdRecibeNavigations))]
        public virtual UsuUsuario UsuIdRecibeNavigation { get; set; } = null!;
    }
}
