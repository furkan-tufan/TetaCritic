using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TetaCritic.Migrations
{
    public partial class YorumlarEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yorum",
                columns: table => new
                {
                    YorumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zaman = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    Derece = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorum", x => x.YorumId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yorum");
        }
    }
}
