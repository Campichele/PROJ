using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieToGo.Migrations
{
    public partial class MVTModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ACTEURS",
            //    columns: table => new
            //    {
            //        ID_ACTEUR = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: true),
            //        PRENOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ACTEURS", x => x.ID_ACTEUR);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DISTRIBUTEUR",
            //    columns: table => new
            //    {
            //        ID_DISTRIBUTEUR = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DISTRIBUTEUR", x => x.ID_DISTRIBUTEUR);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DROIT",
            //    columns: table => new
            //    {
            //        ID_DROIT = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DROIT", x => x.ID_DROIT);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GENRE",
            //    columns: table => new
            //    {
            //        ID_GENRE = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_GENRE", x => x.ID_GENRE);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LANGUE",
            //    columns: table => new
            //    {
            //        ID_LANGUE = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LANGUE", x => x.ID_LANGUE);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NATIONALITE",
            //    columns: table => new
            //    {
            //        ID_NATIONALITE = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NATIONALITE", x => x.ID_NATIONALITE);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "REALISATEUR",
            //    columns: table => new
            //    {
            //        ID_REALISATEUR = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false),
            //        PRENOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_REALISATEUR", x => x.ID_REALISATEUR);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SOUS_TITRE",
            //    columns: table => new
            //    {
            //        ID_SOUS_TITRE = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SOUS_TITRE", x => x.ID_SOUS_TITRE);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UTILISATEUR",
            //    columns: table => new
            //    {
            //        ID_USER = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ID_DROIT = table.Column<short>(nullable: false),
            //        NOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false),
            //        PRENOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false),
            //        EMAIL = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false),
            //        PASSWORD = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
            //        STATUT = table.Column<bool>(nullable: false, comment: "actif/non actif (ban)"),
            //        PSEUDO = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UTILISATEUR", x => x.ID_USER);
            //        table.ForeignKey(
            //            name: "FK_UTILISATEUR_DROIT",
            //            column: x => x.ID_DROIT,
            //            principalTable: "DROIT",
            //            principalColumn: "ID_DROIT",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FILM",
            //    columns: table => new
            //    {
            //        ID_FILM = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ID_DISTRIBUTEUR = table.Column<short>(nullable: false),
            //        ID_SOUS_TITRE = table.Column<short>(nullable: false),
            //        ID_LANGUE = table.Column<short>(nullable: false),
            //        ID_NATIONALITE = table.Column<short>(nullable: false),
            //        NOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false),
            //        DATE_DE_SORTIE = table.Column<DateTime>(type: "datetime", nullable: false),
            //        DESCRIPTION = table.Column<string>(type: "text", nullable: true),
            //        DUREE = table.Column<short>(nullable: false),
            //        PRIX = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
            //        FICHIER = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FILM", x => x.ID_FILM);
            //        table.ForeignKey(
            //            name: "FK_FILM_DISTRIBUTEUR",
            //            column: x => x.ID_DISTRIBUTEUR,
            //            principalTable: "DISTRIBUTEUR",
            //            principalColumn: "ID_DISTRIBUTEUR",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_FILM_LANGUE",
            //            column: x => x.ID_LANGUE,
            //            principalTable: "LANGUE",
            //            principalColumn: "ID_LANGUE",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_FILM_NATIONALITE",
            //            column: x => x.ID_NATIONALITE,
            //            principalTable: "NATIONALITE",
            //            principalColumn: "ID_NATIONALITE",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_FILM_SOUS_TITRE",
            //            column: x => x.ID_SOUS_TITRE,
            //            principalTable: "SOUS_TITRE",
            //            principalColumn: "ID_SOUS_TITRE",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LIST",
            //    columns: table => new
            //    {
            //        ID_LIST = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ID_USER = table.Column<short>(nullable: false),
            //        NOM = table.Column<string>(unicode: false, fixedLength: true, maxLength: 32, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LIST", x => x.ID_LIST);
            //        table.ForeignKey(
            //            name: "FK_LIST_UTILISATEUR",
            //            column: x => x.ID_USER,
            //            principalTable: "UTILISATEUR",
            //            principalColumn: "ID_USER",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "COMMENTAIRE",
            //    columns: table => new
            //    {
            //        ID_COMMENTAIRE = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ID_USER = table.Column<short>(nullable: false),
            //        ID_FILM = table.Column<short>(nullable: false),
            //        COMMENTAIRE = table.Column<string>(unicode: false, fixedLength: true, maxLength: 255, nullable: false),
            //        STATUT = table.Column<bool>(nullable: false, comment: "en attente/approuvé")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_COMMENTAIRE", x => x.ID_COMMENTAIRE);
            //        table.ForeignKey(
            //            name: "FK_COMMENTAIRE_FILM",
            //            column: x => x.ID_FILM,
            //            principalTable: "FILM",
            //            principalColumn: "ID_FILM",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_COMMENTAIRE_UTILISATEUR",
            //            column: x => x.ID_USER,
            //            principalTable: "UTILISATEUR",
            //            principalColumn: "ID_USER",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FAIT_PARTIE",
            //    columns: table => new
            //    {
            //        ID_GENRE = table.Column<short>(nullable: false),
            //        ID_FILM = table.Column<short>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FAIT_PARTIE", x => new { x.ID_GENRE, x.ID_FILM });
            //        table.ForeignKey(
            //            name: "FK_FAIT_PARTIE_FILM",
            //            column: x => x.ID_FILM,
            //            principalTable: "FILM",
            //            principalColumn: "ID_FILM",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_FAIT_PARTIE_GENRE",
            //            column: x => x.ID_GENRE,
            //            principalTable: "GENRE",
            //            principalColumn: "ID_GENRE",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FILM_POSSEDE",
            //    columns: table => new
            //    {
            //        ID_FILM_POSSEDE = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ID_FILM = table.Column<short>(nullable: false),
            //        ID_USER = table.Column<short>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FILM_POSSEDE", x => x.ID_FILM_POSSEDE);
            //        table.ForeignKey(
            //            name: "FK_FILM_POSSEDE_FILM",
            //            column: x => x.ID_FILM,
            //            principalTable: "FILM",
            //            principalColumn: "ID_FILM",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_FILM_POSSEDE_UTILISATEUR",
            //            column: x => x.ID_USER,
            //            principalTable: "UTILISATEUR",
            //            principalColumn: "ID_USER",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "JOUE",
            //    columns: table => new
            //    {
            //        ID_ACTEUR = table.Column<short>(nullable: false),
            //        ID_FILM = table.Column<short>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_JOUE", x => new { x.ID_ACTEUR, x.ID_FILM });
            //        table.ForeignKey(
            //            name: "FK_JOUE_ACTEURS",
            //            column: x => x.ID_ACTEUR,
            //            principalTable: "ACTEURS",
            //            principalColumn: "ID_ACTEUR",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_JOUE_FILM",
            //            column: x => x.ID_FILM,
            //            principalTable: "FILM",
            //            principalColumn: "ID_FILM",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NOTE",
            //    columns: table => new
            //    {
            //        ID_NOTE = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ID_USER = table.Column<short>(nullable: false),
            //        ID_FILM = table.Column<short>(nullable: false),
            //        NOTE = table.Column<byte>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NOTE", x => x.ID_NOTE);
            //        table.ForeignKey(
            //            name: "FK_NOTE_FILM",
            //            column: x => x.ID_FILM,
            //            principalTable: "FILM",
            //            principalColumn: "ID_FILM",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_NOTE_UTILISATEUR",
            //            column: x => x.ID_USER,
            //            principalTable: "UTILISATEUR",
            //            principalColumn: "ID_USER",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "REALISE",
            //    columns: table => new
            //    {
            //        ID_REALISATEUR = table.Column<short>(nullable: false),
            //        ID_FILM = table.Column<short>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_REALISE", x => new { x.ID_REALISATEUR, x.ID_FILM });
            //        table.ForeignKey(
            //            name: "FK_REALISE_FILM",
            //            column: x => x.ID_FILM,
            //            principalTable: "FILM",
            //            principalColumn: "ID_FILM",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_REALISE_REALISATEUR",
            //            column: x => x.ID_REALISATEUR,
            //            principalTable: "REALISATEUR",
            //            principalColumn: "ID_REALISATEUR",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "WISHLIST",
            //    columns: table => new
            //    {
            //        ID_WISHLIST = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ID_FILM = table.Column<short>(nullable: false),
            //        ID_USER = table.Column<short>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_WISHLIST", x => x.ID_WISHLIST);
            //        table.ForeignKey(
            //            name: "FK_WISHLIST_FILM",
            //            column: x => x.ID_FILM,
            //            principalTable: "FILM",
            //            principalColumn: "ID_FILM",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_WISHLIST_UTILISATEUR",
            //            column: x => x.ID_USER,
            //            principalTable: "UTILISATEUR",
            //            principalColumn: "ID_USER",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LIST_F",
            //    columns: table => new
            //    {
            //        ID_LIST_F = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ID_FILM = table.Column<short>(nullable: false),
            //        ID_LIST = table.Column<short>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LIST_F", x => x.ID_LIST_F);
            //        table.ForeignKey(
            //            name: "FK_LIST_F_FILM",
            //            column: x => x.ID_FILM,
            //            principalTable: "FILM",
            //            principalColumn: "ID_FILM",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LIST_F_LIST",
            //            column: x => x.ID_LIST,
            //            principalTable: "LIST",
            //            principalColumn: "ID_LIST",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_COMMENTAIRE_ID_FILM",
            //    table: "COMMENTAIRE",
            //    column: "ID_FILM");

            //migrationBuilder.CreateIndex(
            //    name: "IX_COMMENTAIRE_ID_USER",
            //    table: "COMMENTAIRE",
            //    column: "ID_USER");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FAIT_PARTIE_ID_FILM",
            //    table: "FAIT_PARTIE",
            //    column: "ID_FILM");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FILM_ID_DISTRIBUTEUR",
            //    table: "FILM",
            //    column: "ID_DISTRIBUTEUR");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FILM_ID_LANGUE",
            //    table: "FILM",
            //    column: "ID_LANGUE");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FILM_ID_NATIONALITE",
            //    table: "FILM",
            //    column: "ID_NATIONALITE");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FILM_ID_SOUS_TITRE",
            //    table: "FILM",
            //    column: "ID_SOUS_TITRE");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FILM_POSSEDE_ID_FILM",
            //    table: "FILM_POSSEDE",
            //    column: "ID_FILM");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FILM_POSSEDE_ID_USER",
            //    table: "FILM_POSSEDE",
            //    column: "ID_USER");

            //migrationBuilder.CreateIndex(
            //    name: "IX_JOUE_ID_FILM",
            //    table: "JOUE",
            //    column: "ID_FILM");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LIST_ID_USER",
            //    table: "LIST",
            //    column: "ID_USER");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LIST_F_ID_FILM",
            //    table: "LIST_F",
            //    column: "ID_FILM");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LIST_F_ID_LIST",
            //    table: "LIST_F",
            //    column: "ID_LIST");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NOTE_ID_FILM",
            //    table: "NOTE",
            //    column: "ID_FILM");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NOTE_ID_USER",
            //    table: "NOTE",
            //    column: "ID_USER");

            //migrationBuilder.CreateIndex(
            //    name: "IX_REALISE_ID_FILM",
            //    table: "REALISE",
            //    column: "ID_FILM");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UTILISATEUR_ID_DROIT",
            //    table: "UTILISATEUR",
            //    column: "ID_DROIT");

            //migrationBuilder.CreateIndex(
            //    name: "IX_WISHLIST_ID_FILM",
            //    table: "WISHLIST",
            //    column: "ID_FILM");

            //migrationBuilder.CreateIndex(
            //    name: "IX_WISHLIST_ID_USER",
            //    table: "WISHLIST",
            //    column: "ID_USER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMMENTAIRE");

            migrationBuilder.DropTable(
                name: "FAIT_PARTIE");

            migrationBuilder.DropTable(
                name: "FILM_POSSEDE");

            migrationBuilder.DropTable(
                name: "JOUE");

            migrationBuilder.DropTable(
                name: "LIST_F");

            migrationBuilder.DropTable(
                name: "NOTE");

            migrationBuilder.DropTable(
                name: "REALISE");

            migrationBuilder.DropTable(
                name: "WISHLIST");

            migrationBuilder.DropTable(
                name: "GENRE");

            migrationBuilder.DropTable(
                name: "ACTEURS");

            migrationBuilder.DropTable(
                name: "LIST");

            migrationBuilder.DropTable(
                name: "REALISATEUR");

            migrationBuilder.DropTable(
                name: "FILM");

            migrationBuilder.DropTable(
                name: "UTILISATEUR");

            migrationBuilder.DropTable(
                name: "DISTRIBUTEUR");

            migrationBuilder.DropTable(
                name: "LANGUE");

            migrationBuilder.DropTable(
                name: "NATIONALITE");

            migrationBuilder.DropTable(
                name: "SOUS_TITRE");

            migrationBuilder.DropTable(
                name: "DROIT");
        }
    }
}
