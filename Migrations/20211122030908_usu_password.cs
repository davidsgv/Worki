using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Worki.Migrations
{
    public partial class usu_password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "con_configuraciones",
                columns: table => new
                {
                    con_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    con_Nombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    con_Descripcion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__con_conf__08160352D880DDD9", x => x.con_Id);
                });

            migrationBuilder.CreateTable(
                name: "emp_Empresa",
                columns: table => new
                {
                    emp_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_Nombre = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__emp_Empr__128545298C0CCA01", x => x.emp_Id);
                });

            migrationBuilder.CreateTable(
                name: "EveEventoUsuUsuario",
                columns: table => new
                {
                    EveId = table.Column<int>(type: "int", nullable: false),
                    UsuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EveEventoUsuUsuario", x => new { x.EveId, x.UsuId });
                });

            migrationBuilder.CreateTable(
                name: "GruGrupoUsuUsuario",
                columns: table => new
                {
                    GruId = table.Column<int>(type: "int", nullable: false),
                    UsuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruGrupoUsuUsuario", x => new { x.GruId, x.UsuId });
                });

            migrationBuilder.CreateTable(
                name: "gup_GustosProfesionales",
                columns: table => new
                {
                    gup_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gup_Nombre = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__gup_Gust__06A08E027F3BA663", x => x.gup_Id);
                });

            migrationBuilder.CreateTable(
                name: "GupGustosProfesionalePerPerfil",
                columns: table => new
                {
                    GupId = table.Column<int>(type: "int", nullable: false),
                    PerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GupGustosProfesionalePerPerfil", x => new { x.GupId, x.PerId });
                });

            migrationBuilder.CreateTable(
                name: "hob_Hobbie",
                columns: table => new
                {
                    hob_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hob_Nombre = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__hob_Hobb__FB8321F53702A217", x => x.hob_Id);
                });

            migrationBuilder.CreateTable(
                name: "HobHobbiePerPerfil",
                columns: table => new
                {
                    HobId = table.Column<int>(type: "int", nullable: false),
                    PerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobHobbiePerPerfil", x => new { x.HobId, x.PerId });
                });

            migrationBuilder.CreateTable(
                name: "PosPostUsuUsuario",
                columns: table => new
                {
                    PosId = table.Column<int>(type: "int", nullable: false),
                    UsuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosPostUsuUsuario", x => new { x.PosId, x.UsuId });
                });

            migrationBuilder.CreateTable(
                name: "usu_Usuario",
                columns: table => new
                {
                    usu_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usu_Correo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    usu_Password = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    usu_Nombre = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    usu_Administrador = table.Column<bool>(type: "bit", nullable: false),
                    emp_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usu_Usua__43056304BB8A4015", x => x.usu_Id);
                    table.ForeignKey(
                        name: "fk_usu_emp",
                        column: x => x.emp_Id,
                        principalTable: "emp_Empresa",
                        principalColumn: "emp_Id");
                });

            migrationBuilder.CreateTable(
                name: "chu_ChatUsuario",
                columns: table => new
                {
                    chu_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chu_Fecha = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    chu_Mensaje = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    chu_EsLeido = table.Column<bool>(type: "bit", nullable: false),
                    usu_IdEnvia = table.Column<int>(type: "int", nullable: false),
                    usu_IdRecibe = table.Column<int>(type: "int", nullable: false),
                    chu_Link = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    chu_GifphyId = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chu_Chat__4407C61B65C4046A", x => x.chu_Id);
                    table.ForeignKey(
                        name: "fk_chu_usuEnvia",
                        column: x => x.usu_IdEnvia,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id");
                    table.ForeignKey(
                        name: "fk_chu_usuRecibe",
                        column: x => x.usu_IdRecibe,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id");
                });

            migrationBuilder.CreateTable(
                name: "eti_Etiqueta",
                columns: table => new
                {
                    eti_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__eti_Etiq__610D46360ED5EC02", x => x.eti_Id);
                    table.ForeignKey(
                        name: "fk_eti_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "eve_evento",
                columns: table => new
                {
                    eve_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eve_Nombre = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    eve_Descripcion = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: false),
                    eve_Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    eve_Duracion = table.Column<int>(type: "int", nullable: false),
                    eve_Lugar = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    usu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__eve_even__78B70A9113142260", x => x.eve_Id);
                    table.ForeignKey(
                        name: "fk_eve_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id");
                });

            migrationBuilder.CreateTable(
                name: "gru_Grupo",
                columns: table => new
                {
                    gru_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gru_Imagen = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    gru_Nombre = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    gru_Descripcion = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    gru_Privado = table.Column<bool>(type: "bit", nullable: false),
                    usu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__gru_Grup__FCA16028F9FEB3AA", x => x.gru_Id);
                    table.ForeignKey(
                        name: "fk_gru_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id");
                });

            migrationBuilder.CreateTable(
                name: "not_Notificacion",
                columns: table => new
                {
                    not_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    not_Fecha = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    not_Tipo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    not_Mensaje = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    not_Enviada = table.Column<bool>(type: "bit", nullable: false),
                    usu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__not_Noti__0E685BD87DC3379F", x => x.not_Id);
                    table.ForeignKey(
                        name: "fk_not_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "per_Perfil",
                columns: table => new
                {
                    per_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    per_Imagen = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    per_Cargo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    per_Estado = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    usu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__per_Perf__32A0223F00C7B271", x => x.per_Id);
                    table.ForeignKey(
                        name: "fk_per_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inv_invitado",
                columns: table => new
                {
                    eve_Id = table.Column<int>(type: "int", nullable: false),
                    usu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inv_eve_usu", x => new { x.eve_Id, x.usu_Id });
                    table.ForeignKey(
                        name: "fk_inv_eve",
                        column: x => x.eve_Id,
                        principalTable: "eve_evento",
                        principalColumn: "eve_Id");
                    table.ForeignKey(
                        name: "fk_inv_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id");
                });

            migrationBuilder.CreateTable(
                name: "cal_Calendario",
                columns: table => new
                {
                    cal_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cal_Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    cal_Descripcion = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    gru_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cal_Cale__1EDAD3DA8F1F087A", x => x.cal_Id);
                    table.ForeignKey(
                        name: "fk_cal_gru",
                        column: x => x.gru_Id,
                        principalTable: "gru_Grupo",
                        principalColumn: "gru_Id");
                });

            migrationBuilder.CreateTable(
                name: "chg_ChatGrupo",
                columns: table => new
                {
                    chg_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chg_Fecha = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    chg_Mensaje = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    gru_Id = table.Column<int>(type: "int", nullable: false),
                    usu_Id = table.Column<int>(type: "int", nullable: false),
                    chg_Link = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    chg_GifphyId = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chg_Chat__4483AFE124504C79", x => x.chg_Id);
                    table.ForeignKey(
                        name: "fk_chg_gru",
                        column: x => x.gru_Id,
                        principalTable: "gru_Grupo",
                        principalColumn: "gru_Id");
                    table.ForeignKey(
                        name: "fk_chg_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id");
                });

            migrationBuilder.CreateTable(
                name: "enc_Encuesta",
                columns: table => new
                {
                    enc_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enc_Nombre = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    gru_Id = table.Column<int>(type: "int", nullable: false),
                    usu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__enc_Encu__2BFC405D349E9AE9", x => x.enc_Id);
                    table.ForeignKey(
                        name: "fk_enc_gru",
                        column: x => x.gru_Id,
                        principalTable: "gru_Grupo",
                        principalColumn: "gru_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enc_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id");
                });

            migrationBuilder.CreateTable(
                name: "ing_InvitacionGrupo",
                columns: table => new
                {
                    gru_Id = table.Column<int>(type: "int", nullable: false),
                    usu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ing_gup_usu", x => new { x.gru_Id, x.usu_Id });
                    table.ForeignKey(
                        name: "fk_ing_gup",
                        column: x => x.gru_Id,
                        principalTable: "gru_Grupo",
                        principalColumn: "gru_Id");
                    table.ForeignKey(
                        name: "fk_ing_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id");
                });

            migrationBuilder.CreateTable(
                name: "usg_UsuarioGrupo",
                columns: table => new
                {
                    gru_Id = table.Column<int>(type: "int", nullable: false),
                    usu_Id = table.Column<int>(type: "int", nullable: false),
                    usg_EsAdministrador = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usg_gru_usu", x => new { x.gru_Id, x.usu_Id });
                    table.ForeignKey(
                        name: "fk_usg_gru",
                        column: x => x.gru_Id,
                        principalTable: "gru_Grupo",
                        principalColumn: "gru_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_usg_usu",
                        column: x => x.gru_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cpe_ConfiguracionesPerfil",
                columns: table => new
                {
                    per_Id = table.Column<int>(type: "int", nullable: false),
                    con_Id = table.Column<int>(type: "int", nullable: false),
                    cpe_Valor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pre_per_con", x => new { x.per_Id, x.con_Id });
                    table.ForeignKey(
                        name: "fk_cpe_con",
                        column: x => x.con_Id,
                        principalTable: "con_configuraciones",
                        principalColumn: "con_Id");
                    table.ForeignKey(
                        name: "fk_cpe_per",
                        column: x => x.per_Id,
                        principalTable: "per_Perfil",
                        principalColumn: "per_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gpe_GustosPerfil",
                columns: table => new
                {
                    gup_Id = table.Column<int>(type: "int", nullable: false),
                    per_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gpe_gup_per", x => new { x.gup_Id, x.per_Id });
                    table.ForeignKey(
                        name: "fk_gpe_gup",
                        column: x => x.gup_Id,
                        principalTable: "gup_GustosProfesionales",
                        principalColumn: "gup_Id");
                    table.ForeignKey(
                        name: "fk_gpe_per",
                        column: x => x.per_Id,
                        principalTable: "per_Perfil",
                        principalColumn: "per_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hop_HobbiesPerfil",
                columns: table => new
                {
                    per_Id = table.Column<int>(type: "int", nullable: false),
                    hob_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hop_per_hob", x => new { x.per_Id, x.hob_Id });
                    table.ForeignKey(
                        name: "fk_hop_hob",
                        column: x => x.hob_Id,
                        principalTable: "hob_Hobbie",
                        principalColumn: "hob_Id");
                    table.ForeignKey(
                        name: "fk_hop_per",
                        column: x => x.per_Id,
                        principalTable: "per_Perfil",
                        principalColumn: "per_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_Post",
                columns: table => new
                {
                    pos_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    per_Id = table.Column<int>(type: "int", nullable: true),
                    pos_Fecha = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    pos_Contenido = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    gru_Id = table.Column<int>(type: "int", nullable: true),
                    gru_EsDiscusion = table.Column<bool>(type: "bit", nullable: false),
                    gru_EsImportante = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pos_Post__D1A5EFFA9434D01C", x => x.pos_Id);
                    table.ForeignKey(
                        name: "fk_pos_gru",
                        column: x => x.gru_Id,
                        principalTable: "gru_Grupo",
                        principalColumn: "gru_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pos_per",
                        column: x => x.per_Id,
                        principalTable: "per_Perfil",
                        principalColumn: "per_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pre_PreguntaEncuesta",
                columns: table => new
                {
                    pre_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pre_Pregunta = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    pre_CantidadOpciones = table.Column<int>(type: "int", nullable: false),
                    pre_FechaVencimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    enc_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pre_Preg__E0CFC265163D94D6", x => x.pre_Id);
                    table.ForeignKey(
                        name: "fk_pre_enc",
                        column: x => x.enc_Id,
                        principalTable: "enc_Encuesta",
                        principalColumn: "enc_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adj_adjuntos",
                columns: table => new
                {
                    adj_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adj_Nombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    adj_RutaImagen = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    adj_Tamano = table.Column<int>(type: "int", nullable: false),
                    pos_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__adj_adju__C4AC8F0DE03A6343", x => x.adj_Id);
                    table.ForeignKey(
                        name: "fk_adj_post",
                        column: x => x.pos_Id,
                        principalTable: "pos_Post",
                        principalColumn: "pos_Id");
                });

            migrationBuilder.CreateTable(
                name: "com_Comentario",
                columns: table => new
                {
                    com_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    com_Comentario = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: false),
                    com_Fecha = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    pos_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__com_Come__506777A4748F9A67", x => x.com_Id);
                    table.ForeignKey(
                        name: "fk_com_pos",
                        column: x => x.pos_Id,
                        principalTable: "pos_Post",
                        principalColumn: "pos_Id");
                });

            migrationBuilder.CreateTable(
                name: "cop_compartir",
                columns: table => new
                {
                    usu_Id = table.Column<int>(type: "int", nullable: false),
                    pos_Id = table.Column<int>(type: "int", nullable: false),
                    eti_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cop_comp__430563048DBD25E7", x => x.usu_Id);
                    table.ForeignKey(
                        name: "fk_cop_eti",
                        column: x => x.eti_Id,
                        principalTable: "eti_Etiqueta",
                        principalColumn: "eti_Id");
                    table.ForeignKey(
                        name: "fk_cop_pos",
                        column: x => x.pos_Id,
                        principalTable: "pos_Post",
                        principalColumn: "pos_Id");
                    table.ForeignKey(
                        name: "fk_cop_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "den_Denuncia",
                columns: table => new
                {
                    den_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    den_Fecha = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    usu_Id = table.Column<int>(type: "int", nullable: false),
                    pos_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__den_Denu__C8552B6EDA53D77E", x => x.den_Id);
                    table.ForeignKey(
                        name: "fk_den_pos",
                        column: x => x.pos_Id,
                        principalTable: "pos_Post",
                        principalColumn: "pos_Id");
                    table.ForeignKey(
                        name: "fk_den_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vis_visto",
                columns: table => new
                {
                    pos_Id = table.Column<int>(type: "int", nullable: false),
                    usu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vis_pos_usu", x => new { x.pos_Id, x.usu_Id });
                    table.ForeignKey(
                        name: "fk_vis_pos",
                        column: x => x.pos_Id,
                        principalTable: "pos_Post",
                        principalColumn: "pos_Id");
                    table.ForeignKey(
                        name: "fk_vis_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ope_OpcionEncuesta",
                columns: table => new
                {
                    ope_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ope_Respuesta = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ope_EsCorrecta = table.Column<bool>(type: "bit", nullable: false),
                    pre_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ope_Opci__73A6A6196A7B159D", x => x.ope_Id);
                    table.ForeignKey(
                        name: "fk_ope_pre",
                        column: x => x.pre_Id,
                        principalTable: "pre_PreguntaEncuesta",
                        principalColumn: "pre_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ree_RespuestaEncuesta",
                columns: table => new
                {
                    ree_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usu_Id = table.Column<int>(type: "int", nullable: false),
                    ope_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ree_Resp__8400ADFC40FA6DA5", x => x.ree_Id);
                    table.ForeignKey(
                        name: "fk_ree_ope",
                        column: x => x.ope_Id,
                        principalTable: "ope_OpcionEncuesta",
                        principalColumn: "ope_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ree_usu",
                        column: x => x.usu_Id,
                        principalTable: "usu_Usuario",
                        principalColumn: "usu_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adj_adjuntos_pos_Id",
                table: "adj_adjuntos",
                column: "pos_Id");

            migrationBuilder.CreateIndex(
                name: "IX_cal_Calendario_gru_Id",
                table: "cal_Calendario",
                column: "gru_Id");

            migrationBuilder.CreateIndex(
                name: "IX_chg_ChatGrupo_gru_Id",
                table: "chg_ChatGrupo",
                column: "gru_Id");

            migrationBuilder.CreateIndex(
                name: "IX_chg_ChatGrupo_usu_Id",
                table: "chg_ChatGrupo",
                column: "usu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_chu_ChatUsuario_usu_IdEnvia",
                table: "chu_ChatUsuario",
                column: "usu_IdEnvia");

            migrationBuilder.CreateIndex(
                name: "IX_chu_ChatUsuario_usu_IdRecibe",
                table: "chu_ChatUsuario",
                column: "usu_IdRecibe");

            migrationBuilder.CreateIndex(
                name: "IX_com_Comentario_pos_Id",
                table: "com_Comentario",
                column: "pos_Id");

            migrationBuilder.CreateIndex(
                name: "unique_con_Descripcion",
                table: "con_configuraciones",
                column: "con_Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_con_Nombre",
                table: "con_configuraciones",
                column: "con_Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cop_compartir_eti_Id",
                table: "cop_compartir",
                column: "eti_Id");

            migrationBuilder.CreateIndex(
                name: "IX_cop_compartir_pos_Id",
                table: "cop_compartir",
                column: "pos_Id");

            migrationBuilder.CreateIndex(
                name: "IX_cpe_ConfiguracionesPerfil_con_Id",
                table: "cpe_ConfiguracionesPerfil",
                column: "con_Id");

            migrationBuilder.CreateIndex(
                name: "IX_den_Denuncia_pos_Id",
                table: "den_Denuncia",
                column: "pos_Id");

            migrationBuilder.CreateIndex(
                name: "IX_den_Denuncia_usu_Id",
                table: "den_Denuncia",
                column: "usu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_enc_Encuesta_gru_Id",
                table: "enc_Encuesta",
                column: "gru_Id");

            migrationBuilder.CreateIndex(
                name: "IX_enc_Encuesta_usu_Id",
                table: "enc_Encuesta",
                column: "usu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_eti_Etiqueta_usu_Id",
                table: "eti_Etiqueta",
                column: "usu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_eve_evento_usu_Id",
                table: "eve_evento",
                column: "usu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_gpe_GustosPerfil_per_Id",
                table: "gpe_GustosPerfil",
                column: "per_Id");

            migrationBuilder.CreateIndex(
                name: "IX_gru_Grupo_usu_Id",
                table: "gru_Grupo",
                column: "usu_Id");

            migrationBuilder.CreateIndex(
                name: "unique_gup_Nombre",
                table: "gup_GustosProfesionales",
                column: "gup_Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_hob_Nombre",
                table: "hob_Hobbie",
                column: "hob_Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_hop_HobbiesPerfil_hob_Id",
                table: "hop_HobbiesPerfil",
                column: "hob_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ing_InvitacionGrupo_usu_Id",
                table: "ing_InvitacionGrupo",
                column: "usu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_inv_invitado_usu_Id",
                table: "inv_invitado",
                column: "usu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_not_Notificacion_usu_Id",
                table: "not_Notificacion",
                column: "usu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ope_OpcionEncuesta_pre_Id",
                table: "ope_OpcionEncuesta",
                column: "pre_Id");

            migrationBuilder.CreateIndex(
                name: "Unique_per_usu",
                table: "per_Perfil",
                column: "usu_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pos_Post_gru_Id",
                table: "pos_Post",
                column: "gru_Id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_Post_per_Id",
                table: "pos_Post",
                column: "per_Id");

            migrationBuilder.CreateIndex(
                name: "IX_pre_PreguntaEncuesta_enc_Id",
                table: "pre_PreguntaEncuesta",
                column: "enc_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ree_RespuestaEncuesta_ope_Id",
                table: "ree_RespuestaEncuesta",
                column: "ope_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ree_RespuestaEncuesta_usu_Id",
                table: "ree_RespuestaEncuesta",
                column: "usu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usu_Usuario_emp_Id",
                table: "usu_Usuario",
                column: "emp_Id");

            migrationBuilder.CreateIndex(
                name: "unique_usu_correo",
                table: "usu_Usuario",
                column: "usu_Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vis_visto_usu_Id",
                table: "vis_visto",
                column: "usu_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adj_adjuntos");

            migrationBuilder.DropTable(
                name: "cal_Calendario");

            migrationBuilder.DropTable(
                name: "chg_ChatGrupo");

            migrationBuilder.DropTable(
                name: "chu_ChatUsuario");

            migrationBuilder.DropTable(
                name: "com_Comentario");

            migrationBuilder.DropTable(
                name: "cop_compartir");

            migrationBuilder.DropTable(
                name: "cpe_ConfiguracionesPerfil");

            migrationBuilder.DropTable(
                name: "den_Denuncia");

            migrationBuilder.DropTable(
                name: "EveEventoUsuUsuario");

            migrationBuilder.DropTable(
                name: "gpe_GustosPerfil");

            migrationBuilder.DropTable(
                name: "GruGrupoUsuUsuario");

            migrationBuilder.DropTable(
                name: "GupGustosProfesionalePerPerfil");

            migrationBuilder.DropTable(
                name: "HobHobbiePerPerfil");

            migrationBuilder.DropTable(
                name: "hop_HobbiesPerfil");

            migrationBuilder.DropTable(
                name: "ing_InvitacionGrupo");

            migrationBuilder.DropTable(
                name: "inv_invitado");

            migrationBuilder.DropTable(
                name: "not_Notificacion");

            migrationBuilder.DropTable(
                name: "PosPostUsuUsuario");

            migrationBuilder.DropTable(
                name: "ree_RespuestaEncuesta");

            migrationBuilder.DropTable(
                name: "usg_UsuarioGrupo");

            migrationBuilder.DropTable(
                name: "vis_visto");

            migrationBuilder.DropTable(
                name: "eti_Etiqueta");

            migrationBuilder.DropTable(
                name: "con_configuraciones");

            migrationBuilder.DropTable(
                name: "gup_GustosProfesionales");

            migrationBuilder.DropTable(
                name: "hob_Hobbie");

            migrationBuilder.DropTable(
                name: "eve_evento");

            migrationBuilder.DropTable(
                name: "ope_OpcionEncuesta");

            migrationBuilder.DropTable(
                name: "pos_Post");

            migrationBuilder.DropTable(
                name: "pre_PreguntaEncuesta");

            migrationBuilder.DropTable(
                name: "per_Perfil");

            migrationBuilder.DropTable(
                name: "enc_Encuesta");

            migrationBuilder.DropTable(
                name: "gru_Grupo");

            migrationBuilder.DropTable(
                name: "usu_Usuario");

            migrationBuilder.DropTable(
                name: "emp_Empresa");
        }
    }
}
