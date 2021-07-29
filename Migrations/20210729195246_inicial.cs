using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBancoDigital.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContasDigitais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Conta = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasDigitais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ContasDigitais",
                columns: new[] { "Id", "Conta", "Saldo" },
                values: new object[] { 1, 1, 999.0 });

            migrationBuilder.InsertData(
                table: "ContasDigitais",
                columns: new[] { "Id", "Conta", "Saldo" },
                values: new object[] { 2, 2, 999.0 });

            migrationBuilder.InsertData(
                table: "ContasDigitais",
                columns: new[] { "Id", "Conta", "Saldo" },
                values: new object[] { 3, 3, 999.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasDigitais");
        }
    }
}
