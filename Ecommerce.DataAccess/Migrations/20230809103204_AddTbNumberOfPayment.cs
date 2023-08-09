using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTbNumberOfPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbTools_TbDealOfTheDays_DealOfTheDayId",
                table: "TbTools");

            migrationBuilder.DropForeignKey(
                name: "FK_TbTools_TbNewArrivalProducts_NewArrivalProductId",
                table: "TbTools");

            migrationBuilder.AlterColumn<int>(
                name: "NewArrivalProductId",
                table: "TbTools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DealOfTheDayId",
                table: "TbTools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPaymentId",
                table: "TbTools",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TbNumberOfPayments",
                columns: table => new
                {
                    NumberOfPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolCurrentState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbNumberOfPayments", x => x.NumberOfPaymentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbTools_NumberOfPaymentId",
                table: "TbTools",
                column: "NumberOfPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTools_TbDealOfTheDays_DealOfTheDayId",
                table: "TbTools",
                column: "DealOfTheDayId",
                principalTable: "TbDealOfTheDays",
                principalColumn: "DealOfTheDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTools_TbNewArrivalProducts_NewArrivalProductId",
                table: "TbTools",
                column: "NewArrivalProductId",
                principalTable: "TbNewArrivalProducts",
                principalColumn: "NewArrivalProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTools_TbNumberOfPayments_NumberOfPaymentId",
                table: "TbTools",
                column: "NumberOfPaymentId",
                principalTable: "TbNumberOfPayments",
                principalColumn: "NumberOfPaymentId");
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

            migrationBuilder.DropForeignKey(
                name: "FK_TbTools_TbNumberOfPayments_NumberOfPaymentId",
                table: "TbTools");

            migrationBuilder.DropTable(
                name: "TbNumberOfPayments");

            migrationBuilder.DropIndex(
                name: "IX_TbTools_NumberOfPaymentId",
                table: "TbTools");

            migrationBuilder.DropColumn(
                name: "NumberOfPaymentId",
                table: "TbTools");

            migrationBuilder.AlterColumn<int>(
                name: "NewArrivalProductId",
                table: "TbTools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DealOfTheDayId",
                table: "TbTools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
