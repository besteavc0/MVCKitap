using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube2.KitapMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    KitapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Yazar = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Tur = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Stok = table.Column<int>(type: "int", nullable: false),
                    YayinYili = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.KitapId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kitaplar");
        }
    }
}
