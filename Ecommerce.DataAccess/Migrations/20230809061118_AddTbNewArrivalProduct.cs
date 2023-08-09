using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTbNewArrivalProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbTools_TbDealOfTheDay_DealOfTheDayId",
                table: "TbTools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbDealOfTheDay",
                table: "TbDealOfTheDay");

            migrationBuilder.RenameTable(
                name: "TbDealOfTheDay",
                newName: "TbDealOfTheDays");

            migrationBuilder.AddColumn<int>(
                name: "NewArrivalProductId",
                table: "TbTools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbDealOfTheDays",
                table: "TbDealOfTheDays",
                column: "DealOfTheDayId");

            migrationBuilder.CreateTable(
                name: "TbNewArrivalProducts",
                columns: table => new
                {
                    NewArrivalProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewArrivalProductCurrentState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbNewArrivalProducts", x => x.NewArrivalProductId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbTools_NewArrivalProductId",
                table: "TbTools",
                column: "NewArrivalProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTools_TbDealOfTheDays_DealOfTheDayId",
                table: "TbTools",
                column: "DealOfTheDayId",
                principalTable: "TbDealOfTheDays",
                principalColumn: "DealOfTheDayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbTools_TbNewArrivalProducts_NewArrivalProductId",
                table: "TbTools",
                column: "NewArrivalProductId",
                principalTable: "TbNewArrivalProducts",
                principalColumn: "NewArrivalProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbTools_TbDealOfTheDays_DealOfTheDayId",
                table: "TbTools");

            migrationBuilder.DropForeignKey(
                name: "FK_TbTools_TbNewArrivalProducts_NewArrivalProductId",
                table: "TbTools");

            migrationBuilder.DropTable(
                name: "TbNewArrivalProducts");

            migrationBuilder.DropIndex(
                name: "IX_TbTools_NewArrivalProductId",
                table: "TbTools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbDealOfTheDays",
                table: "TbDealOfTheDays");

            migrationBuilder.DropColumn(
                name: "NewArrivalProductId",
                table: "TbTools");

            migrationBuilder.RenameTable(
                name: "TbDealOfTheDays",
                newName: "TbDealOfTheDay");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbDealOfTheDay",
                table: "TbDealOfTheDay",
                column: "DealOfTheDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTools_TbDealOfTheDay_DealOfTheDayId",
                table: "TbTools",
                column: "DealOfTheDayId",
                principalTable: "TbDealOfTheDay",
                principalColumn: "DealOfTheDayId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
