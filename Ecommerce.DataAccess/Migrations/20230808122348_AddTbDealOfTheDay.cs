using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTbDealOfTheDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TbCategorys",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TbCategorys",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TbCurrencys",
                keyColumn: "CurrencyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TbCurrencys",
                keyColumn: "CurrencyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TbCurrencys",
                keyColumn: "CurrencyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TbDepartments",
                keyColumn: "DepartmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TbDepartments",
                keyColumn: "DepartmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TbImageTools",
                keyColumn: "ImageTool",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TbImageTools",
                keyColumn: "ImageTool",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TbImageTools",
                keyColumn: "ImageTool",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TbImageTools",
                keyColumn: "ImageTool",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TbImageTools",
                keyColumn: "ImageTool",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TbLanguages",
                keyColumn: "LanguageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TbLanguages",
                keyColumn: "LanguageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TbTeams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TbTeams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TbTeams",
                keyColumn: "TeamId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TbTeams",
                keyColumn: "TeamId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TbTellUss",
                keyColumn: "TellId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TbTools",
                keyColumn: "ToolId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TbAbouts",
                keyColumn: "AboutId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TbCategorys",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TbCompanyInformations",
                keyColumn: "CompanyInformationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TbDepartments",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TbTools",
                keyColumn: "ToolId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TbTools",
                keyColumn: "ToolId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TbTools",
                keyColumn: "ToolId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TbTools",
                keyColumn: "ToolId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TbCategorys",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TbCategorys",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TbDepartments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TbDepartments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "DealOfTheDayId",
                table: "TbTools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TbDealOfTheDay",
                columns: table => new
                {
                    DealOfTheDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealOfTheDayToolProductNewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DealOfTheDayToolrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DealOfTheDayToolDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbDealOfTheDay", x => x.DealOfTheDayId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbTools_DealOfTheDayId",
                table: "TbTools",
                column: "DealOfTheDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTools_TbDealOfTheDay_DealOfTheDayId",
                table: "TbTools",
                column: "DealOfTheDayId",
                principalTable: "TbDealOfTheDay",
                principalColumn: "DealOfTheDayId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbTools_TbDealOfTheDay_DealOfTheDayId",
                table: "TbTools");

            migrationBuilder.DropTable(
                name: "TbDealOfTheDay");

            migrationBuilder.DropIndex(
                name: "IX_TbTools_DealOfTheDayId",
                table: "TbTools");

            migrationBuilder.DropColumn(
                name: "DealOfTheDayId",
                table: "TbTools");

            migrationBuilder.InsertData(
                table: "TbAbouts",
                columns: new[] { "AboutId", "AboutAwardsWinned", "AboutCurrentState", "AboutDescription", "AboutDescriptionImg", "AboutHappyCustomer", "AboutHoursWorked", "AboutProjectDone", "AboutTitelDescription", "AboutUsImg" },
                values: new object[] { 1, 10, 1, "وصف المعلومات عنا", "about_description_img.jpg", 100, 5000, 50, "عنوان الوصف", "about_img.jpg" });

            migrationBuilder.InsertData(
                table: "TbCompanyInformations",
                columns: new[] { "CompanyInformationID", "CompanyInformationAddress", "CompanyInformationCurrentState", "CompanyInformationDescription", "CompanyInformationEmail", "CompanyInformationName", "CompanyInformationPhone" },
                values: new object[] { 1, "عنوان الشركة", 1, "وصف الشركة", "company@example.com", "اسم الشركة", "1234567890" });

            migrationBuilder.InsertData(
                table: "TbDepartments",
                columns: new[] { "DepartmentId", "DepartmentCurrentState", "DepartmentName" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "SciFi" },
                    { 3, 3, "History" },
                    { 4, 4, "Comedy" },
                    { 5, 5, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "TbTellUss",
                columns: new[] { "TellId", "TellCurrentState", "TellEmail", "TellMessage", "TellName", "TellSubject" },
                values: new object[] { 1, 1, "example@example.com", "نص الرسالة", "اسمك", "عنوان الرسالة" });

            migrationBuilder.InsertData(
                table: "TbCategorys",
                columns: new[] { "CategoryId", "CategoryCurrentState", "CategoryName", "DepartmentId" },
                values: new object[,]
                {
                    { 1, 1, "Action", 1 },
                    { 2, 2, "SciFi", 1 },
                    { 3, 3, "History", 2 },
                    { 4, 4, "Comedy", 2 },
                    { 5, 5, "Drama", 3 }
                });

            migrationBuilder.InsertData(
                table: "TbCurrencys",
                columns: new[] { "CurrencyId", "CompanyInformationID", "CurrencyCurrentState", "CurrencyName" },
                values: new object[,]
                {
                    { 1, 1, 1, "SDG" },
                    { 2, 1, 1, "USD" },
                    { 3, 1, 1, "SAR" }
                });

            migrationBuilder.InsertData(
                table: "TbLanguages",
                columns: new[] { "LanguageId", "CompanyInformationID", "LanguageCurrentState", "LanguageName" },
                values: new object[,]
                {
                    { 1, 1, 1, "عربي" },
                    { 2, 1, 1, "English" }
                });

            migrationBuilder.InsertData(
                table: "TbTeams",
                columns: new[] { "TeamId", "AboutId", "TeamDescription", "TeamImg", "TeamName", "TeamTitle" },
                values: new object[,]
                {
                    { 1, 1, "وصف العضو 1", "team_img1.jpg", "عضو الفريق 1", "مسمى الفريق 1" },
                    { 2, 1, "وصف العضو 2", "team_img2.jpg", "عضو الفريق 2", "مسمى الفريق 2" },
                    { 3, 1, "وصف العضو 3", "team_img3.jpg", "عضو الفريق 3", "مسمى الفريق 3" },
                    { 4, 1, "وصف العضو 4", "team_img4.jpg", "عضو الفريق 4", "مسمى الفريق 4" }
                });

            migrationBuilder.InsertData(
                table: "TbTools",
                columns: new[] { "ToolId", "CategoryId", "ToolCurrentState", "ToolDescription", "ToolName", "ToolProductPrice", "ToolSticker" },
                values: new object[,]
                {
                    { 1, 1, 1, "A heavy-duty hammer for construction work", "Hammer", 10.99m, "A1" },
                    { 2, 1, 1, "A versatile screwdriver for various tasks", "Screwdriver", 5.99m, "B1" },
                    { 3, 2, 1, "A powerful telescope for stargazing", "Telescope", 99.99m, "C1" },
                    { 4, 2, 1, "A high-resolution camera for capturing moments", "Camera", 199.99m, "D1" },
                    { 5, 3, 1, "An informative book on historical events", "Book", 19.99m, "E1" }
                });

            migrationBuilder.InsertData(
                table: "TbImageTools",
                columns: new[] { "ImageTool", "ImageCurrentState", "ToolId", "ToolProductImgPrimary", "ToolProductImgSecondry" },
                values: new object[,]
                {
                    { 1, 1, 1, "image1.jpg", "image1_secondary.jpg" },
                    { 2, 1, 1, "image2.jpg", "image2_secondary.jpg" },
                    { 3, 1, 2, "image3.jpg", "image3_secondary.jpg" },
                    { 4, 1, 3, "image4.jpg", "image4_secondary.jpg" },
                    { 5, 1, 4, "image5.jpg", "image5_secondary.jpg" }
                });
        }
    }
}
