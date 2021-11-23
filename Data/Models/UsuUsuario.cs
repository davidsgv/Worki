using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Worki.Data.Models
{
    [Table("usu_Usuario")]
    [Index(nameof(UsuCorreo), Name = "unique_usu_correo", IsUnique = true)]
    public partial class UsuUsuario
    {
        public UsuUsuario()
        {
            ChgChatGrupos = new HashSet<ChgChatGrupo>();
            ChuChatUsuarioUsuIdEnviaNavigations = new HashSet<ChuChatUsuario>();
            ChuChatUsuarioUsuIdRecibeNavigations = new HashSet<ChuChatUsuario>();
            DenDenuncia = new HashSet<DenDenuncium>();
            EncEncuesta = new HashSet<EncEncuestum>();
            EtiEtiqueta = new HashSet<EtiEtiquetum>();
            EveEventos = new HashSet<EveEvento>();
            GruGrupos = new HashSet<GruGrupo>();
            NotNotificacions = new HashSet<NotNotificacion>();
            ReeRespuestaEncuesta = new HashSet<ReeRespuestaEncuestum>();
            UsgUsuarioGrupos = new HashSet<UsgUsuarioGrupo>();
            Eves = new HashSet<EveEvento>();
            Grus = new HashSet<GruGrupo>();
            Pos = new HashSet<PosPost>();
        }

        [Key]
        [Column("usu_Id")]
        public int UsuId { get; set; }

        [Column("usu_Correo")]
        [StringLength(500)]
        [Unicode(false)]
        [Required, EmailAddress, Display(Name ="Correo")]
        public string UsuCorreo { get; set; } = null!;

        [Column("usu_Password")]
        [StringLength(500)]
        [Unicode(false)]
        [Required, Display(Name ="Contraseña")]
        public string UsuPassword { get; set; } = null!;

        [Column("usu_Nombre")]
        [StringLength(500)]
        [Unicode(false)]
        [Required, Display(Name ="Nombre Usuario")]
        public string UsuNombre { get; set; } = null!;

        [Column("usu_Administrador")]
        public bool UsuAdministrador { get; set; } = true;

        [Column("emp_Id")]
        [Required]
        public int EmpId { get; set; }



        [ForeignKey(nameof(EmpId))]
        [InverseProperty(nameof(EmpEmpresa.UsuUsuarios))]
        public virtual EmpEmpresa Emp { get; set; } = null!;

        [InverseProperty("Usu")]
        public virtual CopCompartir CopCompartir { get; set; } = null!;
        [InverseProperty("Usu")]
        public virtual PerPerfil PerPerfil { get; set; } = null!;
        [InverseProperty(nameof(ChgChatGrupo.Usu))]
        public virtual ICollection<ChgChatGrupo> ChgChatGrupos { get; set; }
        [InverseProperty(nameof(ChuChatUsuario.UsuIdEnviaNavigation))]
        public virtual ICollection<ChuChatUsuario> ChuChatUsuarioUsuIdEnviaNavigations { get; set; }
        [InverseProperty(nameof(ChuChatUsuario.UsuIdRecibeNavigation))]
        public virtual ICollection<ChuChatUsuario> ChuChatUsuarioUsuIdRecibeNavigations { get; set; }
        [InverseProperty(nameof(DenDenuncium.Usu))]
        public virtual ICollection<DenDenuncium> DenDenuncia { get; set; }
        [InverseProperty(nameof(EncEncuestum.Usu))]
        public virtual ICollection<EncEncuestum> EncEncuesta { get; set; }
        [InverseProperty(nameof(EtiEtiquetum.Usu))]
        public virtual ICollection<EtiEtiquetum> EtiEtiqueta { get; set; }
        [InverseProperty(nameof(EveEvento.Usu))]
        public virtual ICollection<EveEvento> EveEventos { get; set; }
        [InverseProperty(nameof(GruGrupo.Usu))]
        public virtual ICollection<GruGrupo> GruGrupos { get; set; }
        [InverseProperty(nameof(NotNotificacion.Usu))]
        public virtual ICollection<NotNotificacion> NotNotificacions { get; set; }
        [InverseProperty(nameof(ReeRespuestaEncuestum.Usu))]
        public virtual ICollection<ReeRespuestaEncuestum> ReeRespuestaEncuesta { get; set; }
        [InverseProperty(nameof(UsgUsuarioGrupo.GruNavigation))]
        public virtual ICollection<UsgUsuarioGrupo> UsgUsuarioGrupos { get; set; }

        [ForeignKey("UsuId")]
        [InverseProperty(nameof(EveEvento.Usus))]
        public virtual ICollection<EveEvento> Eves { get; set; }
        [ForeignKey("UsuId")]
        [InverseProperty(nameof(GruGrupo.Usus))]
        public virtual ICollection<GruGrupo> Grus { get; set; }
        [ForeignKey("UsuId")]
        [InverseProperty(nameof(PosPost.Usus))]
        public virtual ICollection<PosPost> Pos { get; set; }
    }
}
