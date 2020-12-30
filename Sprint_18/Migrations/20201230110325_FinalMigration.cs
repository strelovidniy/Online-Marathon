using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskAuthenticationAuthorization.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerTypeId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BuyerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BuyerTypeId",
                table: "Customers",
                column: "BuyerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_BuyerTypes_BuyerTypeId",
                table: "Customers",
                column: "BuyerTypeId",
                principalTable: "BuyerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_BuyerTypes_BuyerTypeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "BuyerTypes");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BuyerTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BuyerTypeId",
                table: "Customers");
        }
    }
}
