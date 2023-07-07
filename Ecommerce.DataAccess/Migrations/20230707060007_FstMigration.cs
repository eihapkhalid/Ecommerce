using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbAbouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUsImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AboutDescriptionImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AboutTitelDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AboutDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AboutHappyCustomer = table.Column<int>(type: "int", nullable: false),
                    AboutHoursWorked = table.Column<int>(type: "int", nullable: false),
                    AboutAwardsWinned = table.Column<int>(type: "int", nullable: false),
                    AboutProjectDone = table.Column<int>(type: "int", nullable: false),
                    AboutCurrentState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbAbouts", x => x.AboutId);
                });

            migrationBuilder.CreateTable(
                name: "TbCompanyInformations",
                columns: table => new
                {
                    CompanyInformationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyInformationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyInformationDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompanyInformationAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyInformationPhone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CompanyInformationEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyInformationCurrentState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCompanyInformations", x => x.CompanyInformationID);
                });

            migrationBuilder.CreateTable(
                name: "TbDepartments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentCurrentState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbDepartments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "TbTellUss",
                columns: table => new
                {
                    TellId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TellName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TellEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TellSubject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TellMessage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TellCurrentState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTellUss", x => x.TellId);
                });

            migrationBuilder.CreateTable(
                name: "TbTeams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TeamTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TeamDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TeamImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AboutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTeams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_TbTeams_TbAbouts_AboutId",
                        column: x => x.AboutId,
                        principalTable: "TbAbouts",
                        principalColumn: "AboutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbCurrencys",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CurrencyCurrentState = table.Column<int>(type: "int", nullable: false),
                    CompanyInformationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCurrencys", x => x.CurrencyId);
                    table.ForeignKey(
                        name: "FK_TbCurrencys_TbCompanyInformations_CompanyInformationID",
                        column: x => x.CompanyInformationID,
                        principalTable: "TbCompanyInformations",
                        principalColumn: "CompanyInformationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbLanguages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    LanguageCurrentState = table.Column<int>(type: "int", nullable: false),
                    CompanyInformationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbLanguages", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_TbLanguages_TbCompanyInformations_CompanyInformationID",
                        column: x => x.CompanyInformationID,
                        principalTable: "TbCompanyInformations",
                        principalColumn: "CompanyInformationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbCategorys",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryCurrentState = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategorys", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_TbCategorys_TbDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TbDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbTools",
                columns: table => new
                {
                    ToolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ToolCurrentState = table.Column<int>(type: "int", nullable: false),
                    ToolSticker = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ToolDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ToolProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTools", x => x.ToolId);
                    table.ForeignKey(
                        name: "FK_TbTools_TbCategorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TbCategorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbImageTools",
                columns: table => new
                {
                    ImageTool = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolProductImgPrimary = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ToolProductImgSecondry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageCurrentState = table.Column<int>(type: "int", nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbImageTools", x => x.ImageTool);
                    table.ForeignKey(
                        name: "FK_TbImageTools_TbTools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "TbTools",
                        principalColumn: "ToolId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TbCategorys_DepartmentId",
                table: "TbCategorys",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TbCurrencys_CompanyInformationID",
                table: "TbCurrencys",
                column: "CompanyInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_TbImageTools_ToolId",
                table: "TbImageTools",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLanguages_CompanyInformationID",
                table: "TbLanguages",
                column: "CompanyInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_TbTeams_AboutId",
                table: "TbTeams",
                column: "AboutId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTools_CategoryId",
                table: "TbTools",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbCurrencys");

            migrationBuilder.DropTable(
                name: "TbImageTools");

            migrationBuilder.DropTable(
                name: "TbLanguages");

            migrationBuilder.DropTable(
                name: "TbTeams");

            migrationBuilder.DropTable(
                name: "TbTellUss");

            migrationBuilder.DropTable(
                name: "TbTools");

            migrationBuilder.DropTable(
                name: "TbCompanyInformations");

            migrationBuilder.DropTable(
                name: "TbAbouts");

            migrationBuilder.DropTable(
                name: "TbCategorys");

            migrationBuilder.DropTable(
                name: "TbDepartments");
        }
    }
}
