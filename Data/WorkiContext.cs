using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Worki.Data.Models;

namespace Worki.Data
{
    public partial class WorkiContext : DbContext
    {
        public WorkiContext()
        {
        }

        public WorkiContext(DbContextOptions<WorkiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdjAdjunto> AdjAdjuntos { get; set; } = null!;
        public virtual DbSet<CalCalendario> CalCalendarios { get; set; } = null!;
        public virtual DbSet<ChgChatGrupo> ChgChatGrupos { get; set; } = null!;
        public virtual DbSet<ChuChatUsuario> ChuChatUsuarios { get; set; } = null!;
        public virtual DbSet<ComComentario> ComComentarios { get; set; } = null!;
        public virtual DbSet<ConConfiguracione> ConConfiguraciones { get; set; } = null!;
        public virtual DbSet<CopCompartir> CopCompartirs { get; set; } = null!;
        public virtual DbSet<CpeConfiguracionesPerfil> CpeConfiguracionesPerfils { get; set; } = null!;
        public virtual DbSet<DenDenuncium> DenDenuncia { get; set; } = null!;
        public virtual DbSet<EmpEmpresa> EmpEmpresas { get; set; } = null!;
        public virtual DbSet<EncEncuestum> EncEncuesta { get; set; } = null!;
        public virtual DbSet<EtiEtiquetum> EtiEtiqueta { get; set; } = null!;
        public virtual DbSet<EveEvento> EveEventos { get; set; } = null!;
        public virtual DbSet<GruGrupo> GruGrupos { get; set; } = null!;
        public virtual DbSet<GupGustosProfesionale> GupGustosProfesionales { get; set; } = null!;
        public virtual DbSet<HobHobbie> HobHobbies { get; set; } = null!;
        public virtual DbSet<NotNotificacion> NotNotificacions { get; set; } = null!;
        public virtual DbSet<OpeOpcionEncuestum> OpeOpcionEncuesta { get; set; } = null!;
        public virtual DbSet<PerPerfil> PerPerfils { get; set; } = null!;
        public virtual DbSet<PosPost> PosPosts { get; set; } = null!;
        public virtual DbSet<PrePreguntaEncuestum> PrePreguntaEncuesta { get; set; } = null!;
        public virtual DbSet<ReeRespuestaEncuestum> ReeRespuestaEncuesta { get; set; } = null!;
        public virtual DbSet<UsgUsuarioGrupo> UsgUsuarioGrupos { get; set; } = null!;
        public virtual DbSet<UsuUsuario> UsuUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Worki;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdjAdjunto>(entity =>
            {
                entity.HasKey(e => e.AdjId)
                    .HasName("PK__adj_adju__C4AC8F0DE03A6343");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.AdjAdjuntos)
                    .HasForeignKey(d => d.PosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_adj_post");
            });

            modelBuilder.Entity<CalCalendario>(entity =>
            {
                entity.HasKey(e => e.CalId)
                    .HasName("PK__cal_Cale__1EDAD3DA8F1F087A");

                entity.HasOne(d => d.Gru)
                    .WithMany(p => p.CalCalendarios)
                    .HasForeignKey(d => d.GruId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cal_gru");
            });

            modelBuilder.Entity<ChgChatGrupo>(entity =>
            {
                entity.HasKey(e => e.ChgId)
                    .HasName("PK__chg_Chat__4483AFE124504C79");

                entity.Property(e => e.ChgFecha).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Gru)
                    .WithMany(p => p.ChgChatGrupos)
                    .HasForeignKey(d => d.GruId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chg_gru");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.ChgChatGrupos)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chg_usu");
            });

            modelBuilder.Entity<ChuChatUsuario>(entity =>
            {
                entity.HasKey(e => e.ChuId)
                    .HasName("PK__chu_Chat__4407C61B65C4046A");

                entity.Property(e => e.ChuFecha).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.UsuIdEnviaNavigation)
                    .WithMany(p => p.ChuChatUsuarioUsuIdEnviaNavigations)
                    .HasForeignKey(d => d.UsuIdEnvia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chu_usuEnvia");

                entity.HasOne(d => d.UsuIdRecibeNavigation)
                    .WithMany(p => p.ChuChatUsuarioUsuIdRecibeNavigations)
                    .HasForeignKey(d => d.UsuIdRecibe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chu_usuRecibe");
            });

            modelBuilder.Entity<ComComentario>(entity =>
            {
                entity.HasKey(e => e.ComId)
                    .HasName("PK__com_Come__506777A4748F9A67");

                entity.Property(e => e.ComFecha).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.ComComentarios)
                    .HasForeignKey(d => d.PosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_com_pos");
            });

            modelBuilder.Entity<ConConfiguracione>(entity =>
            {
                entity.HasKey(e => e.ConId)
                    .HasName("PK__con_conf__08160352D880DDD9");
            });

            modelBuilder.Entity<CopCompartir>(entity =>
            {
                entity.HasKey(e => e.UsuId)
                    .HasName("PK__cop_comp__430563048DBD25E7");

                entity.Property(e => e.UsuId).ValueGeneratedNever();

                entity.HasOne(d => d.Eti)
                    .WithMany(p => p.CopCompartirs)
                    .HasForeignKey(d => d.EtiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cop_eti");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.CopCompartirs)
                    .HasForeignKey(d => d.PosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cop_pos");

                entity.HasOne(d => d.Usu)
                    .WithOne(p => p.CopCompartir)
                    .HasForeignKey<CopCompartir>(d => d.UsuId)
                    .HasConstraintName("fk_cop_usu");
            });

            modelBuilder.Entity<CpeConfiguracionesPerfil>(entity =>
            {
                entity.HasKey(e => new { e.PerId, e.ConId })
                    .HasName("pk_pre_per_con");

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.CpeConfiguracionesPerfils)
                    .HasForeignKey(d => d.ConId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cpe_con");

                entity.HasOne(d => d.Per)
                    .WithMany(p => p.CpeConfiguracionesPerfils)
                    .HasForeignKey(d => d.PerId)
                    .HasConstraintName("fk_cpe_per");
            });

            modelBuilder.Entity<DenDenuncium>(entity =>
            {
                entity.HasKey(e => e.DenId)
                    .HasName("PK__den_Denu__C8552B6EDA53D77E");

                entity.Property(e => e.DenFecha).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.DenDenuncia)
                    .HasForeignKey(d => d.PosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_den_pos");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.DenDenuncia)
                    .HasForeignKey(d => d.UsuId)
                    .HasConstraintName("fk_den_usu");
            });

            modelBuilder.Entity<EmpEmpresa>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__emp_Empr__128545298C0CCA01");
            });

            modelBuilder.Entity<EncEncuestum>(entity =>
            {
                entity.HasKey(e => e.EncId)
                    .HasName("PK__enc_Encu__2BFC405D349E9AE9");

                entity.HasOne(d => d.Gru)
                    .WithMany(p => p.EncEncuesta)
                    .HasForeignKey(d => d.GruId)
                    .HasConstraintName("fk_enc_gru");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.EncEncuesta)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_enc_usu");
            });

            modelBuilder.Entity<EtiEtiquetum>(entity =>
            {
                entity.HasKey(e => e.EtiId)
                    .HasName("PK__eti_Etiq__610D46360ED5EC02");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.EtiEtiqueta)
                    .HasForeignKey(d => d.UsuId)
                    .HasConstraintName("fk_eti_usu");
            });

            modelBuilder.Entity<EveEvento>(entity =>
            {
                entity.HasKey(e => e.EveId)
                    .HasName("PK__eve_even__78B70A9113142260");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.EveEventos)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_eve_usu");

                entity.HasMany(d => d.Usus)
                    .WithMany(p => p.Eves)
                    .UsingEntity<Dictionary<string, object>>(
                        "InvInvitado",
                        l => l.HasOne<UsuUsuario>().WithMany().HasForeignKey("UsuId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_inv_usu"),
                        r => r.HasOne<EveEvento>().WithMany().HasForeignKey("EveId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_inv_eve"),
                        j =>
                        {
                            j.HasKey("EveId", "UsuId").HasName("pk_inv_eve_usu");

                            j.ToTable("inv_invitado");

                            j.IndexerProperty<int>("EveId").HasColumnName("eve_Id");

                            j.IndexerProperty<int>("UsuId").HasColumnName("usu_Id");
                        });
            });

            modelBuilder.Entity<GruGrupo>(entity =>
            {
                entity.HasKey(e => e.GruId)
                    .HasName("PK__gru_Grup__FCA16028F9FEB3AA");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.GruGrupos)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gru_usu");

                entity.HasMany(d => d.Usus)
                    .WithMany(p => p.Grus)
                    .UsingEntity<Dictionary<string, object>>(
                        "IngInvitacionGrupo",
                        l => l.HasOne<UsuUsuario>().WithMany().HasForeignKey("UsuId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_ing_usu"),
                        r => r.HasOne<GruGrupo>().WithMany().HasForeignKey("GruId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_ing_gup"),
                        j =>
                        {
                            j.HasKey("GruId", "UsuId").HasName("pk_ing_gup_usu");

                            j.ToTable("ing_InvitacionGrupo");

                            j.IndexerProperty<int>("GruId").HasColumnName("gru_Id");

                            j.IndexerProperty<int>("UsuId").HasColumnName("usu_Id");
                        });
            });

            modelBuilder.Entity<GupGustosProfesionale>(entity =>
            {
                entity.HasKey(e => e.GupId)
                    .HasName("PK__gup_Gust__06A08E027F3BA663");

                entity.HasMany(d => d.Pers)
                    .WithMany(p => p.Gups)
                    .UsingEntity<Dictionary<string, object>>(
                        "GpeGustosPerfil",
                        l => l.HasOne<PerPerfil>().WithMany().HasForeignKey("PerId").HasConstraintName("fk_gpe_per"),
                        r => r.HasOne<GupGustosProfesionale>().WithMany().HasForeignKey("GupId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_gpe_gup"),
                        j =>
                        {
                            j.HasKey("GupId", "PerId").HasName("pk_gpe_gup_per");

                            j.ToTable("gpe_GustosPerfil");

                            j.IndexerProperty<int>("GupId").HasColumnName("gup_Id");

                            j.IndexerProperty<int>("PerId").HasColumnName("per_Id");
                        });
            });

            modelBuilder.Entity<HobHobbie>(entity =>
            {
                entity.HasKey(e => e.HobId)
                    .HasName("PK__hob_Hobb__FB8321F53702A217");
            });

            modelBuilder.Entity<NotNotificacion>(entity =>
            {
                entity.HasKey(e => e.NotId)
                    .HasName("PK__not_Noti__0E685BD87DC3379F");

                entity.Property(e => e.NotFecha).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.NotNotificacions)
                    .HasForeignKey(d => d.UsuId)
                    .HasConstraintName("fk_not_usu");
            });

            modelBuilder.Entity<OpeOpcionEncuestum>(entity =>
            {
                entity.HasKey(e => e.OpeId)
                    .HasName("PK__ope_Opci__73A6A6196A7B159D");

                entity.HasOne(d => d.Pre)
                    .WithMany(p => p.OpeOpcionEncuesta)
                    .HasForeignKey(d => d.PreId)
                    .HasConstraintName("fk_ope_pre");
            });

            modelBuilder.Entity<PerPerfil>(entity =>
            {
                entity.HasKey(e => e.PerId)
                    .HasName("PK__per_Perf__32A0223F00C7B271");

                entity.HasOne(d => d.Usu)
                    .WithOne(p => p.PerPerfil)
                    .HasForeignKey<PerPerfil>(d => d.UsuId)
                    .HasConstraintName("fk_per_usu");

                entity.HasMany(d => d.Hobs)
                    .WithMany(p => p.Pers)
                    .UsingEntity<Dictionary<string, object>>(
                        "HopHobbiesPerfil",
                        l => l.HasOne<HobHobbie>().WithMany().HasForeignKey("HobId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_hop_hob"),
                        r => r.HasOne<PerPerfil>().WithMany().HasForeignKey("PerId").HasConstraintName("fk_hop_per"),
                        j =>
                        {
                            j.HasKey("PerId", "HobId").HasName("pk_hop_per_hob");

                            j.ToTable("hop_HobbiesPerfil");

                            j.IndexerProperty<int>("PerId").HasColumnName("per_Id");

                            j.IndexerProperty<int>("HobId").HasColumnName("hob_Id");
                        });
            });

            modelBuilder.Entity<PosPost>(entity =>
            {
                entity.HasKey(e => e.PosId)
                    .HasName("PK__pos_Post__D1A5EFFA9434D01C");

                entity.Property(e => e.PosFecha).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Gru)
                    .WithMany(p => p.PosPosts)
                    .HasForeignKey(d => d.GruId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_pos_gru");

                entity.HasOne(d => d.Per)
                    .WithMany(p => p.PosPosts)
                    .HasForeignKey(d => d.PerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_pos_per");

                entity.HasMany(d => d.Usus)
                    .WithMany(p => p.Pos)
                    .UsingEntity<Dictionary<string, object>>(
                        "VisVisto",
                        l => l.HasOne<UsuUsuario>().WithMany().HasForeignKey("UsuId").HasConstraintName("fk_vis_usu"),
                        r => r.HasOne<PosPost>().WithMany().HasForeignKey("PosId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_vis_pos"),
                        j =>
                        {
                            j.HasKey("PosId", "UsuId").HasName("pk_vis_pos_usu");

                            j.ToTable("vis_visto");

                            j.IndexerProperty<int>("PosId").HasColumnName("pos_Id");

                            j.IndexerProperty<int>("UsuId").HasColumnName("usu_Id");
                        });
            });

            modelBuilder.Entity<PrePreguntaEncuestum>(entity =>
            {
                entity.HasKey(e => e.PreId)
                    .HasName("PK__pre_Preg__E0CFC265163D94D6");

                entity.HasOne(d => d.Enc)
                    .WithMany(p => p.PrePreguntaEncuesta)
                    .HasForeignKey(d => d.EncId)
                    .HasConstraintName("fk_pre_enc");
            });

            modelBuilder.Entity<ReeRespuestaEncuestum>(entity =>
            {
                entity.HasKey(e => e.ReeId)
                    .HasName("PK__ree_Resp__8400ADFC40FA6DA5");

                entity.HasOne(d => d.Ope)
                    .WithMany(p => p.ReeRespuestaEncuesta)
                    .HasForeignKey(d => d.OpeId)
                    .HasConstraintName("fk_ree_ope");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.ReeRespuestaEncuesta)
                    .HasForeignKey(d => d.UsuId)
                    .HasConstraintName("fk_ree_usu");
            });

            modelBuilder.Entity<UsgUsuarioGrupo>(entity =>
            {
                entity.HasKey(e => new { e.GruId, e.UsuId })
                    .HasName("pk_usg_gru_usu");

                entity.HasOne(d => d.Gru)
                    .WithMany(p => p.UsgUsuarioGrupos)
                    .HasForeignKey(d => d.GruId)
                    .HasConstraintName("fk_usg_gru");

                entity.HasOne(d => d.GruNavigation)
                    .WithMany(p => p.UsgUsuarioGrupos)
                    .HasForeignKey(d => d.GruId)
                    .HasConstraintName("fk_usg_usu");
            });

            modelBuilder.Entity<UsuUsuario>(entity =>
            {
                entity.HasKey(e => e.UsuId)
                    .HasName("PK__usu_Usua__43056304BB8A4015");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.UsuUsuarios)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usu_emp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
