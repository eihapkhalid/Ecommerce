using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TbCompanyInformation> TbCompanyInformations { get; set; }
        public DbSet<TbLanguage> TbLanguages { get; set; }
        public DbSet<TbCurrency> TbCurrencys { get; set; }
        public DbSet<TbDepartment> TbDepartments { get; set; }
        public DbSet<TbCategory> TbCategorys { get; set; }
        public DbSet<TbTool> TbTools { get; set; }
        public DbSet<TbImageTool> TbImageTools { get; set; }
        public DbSet<TbAbout> TbAbouts { get; set; }
        public DbSet<TbTeam> TbTeams { get; set; }
        public DbSet<TbTellUs> TbTellUss { get; set; }
        public DbSet<TbDealOfTheDay> TbDealOfTheDays { get; set; }
        public DbSet<TbNewArrivalProduct> TbNewArrivalProducts { get; set; }
        public DbSet<TbNumberOfPayment> TbNumberOfPayments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TbCompanyInformation>()
                     .HasMany(c => c._TbLanguage)
                     .WithOne(b => b._TbCompanyInformation)
                     .HasForeignKey(b => b.CompanyInformationID);

            modelBuilder.Entity<TbCompanyInformation>()
                     .HasMany(c => c._TbCurrency)
                     .WithOne(b => b._TbCompanyInformation)
                     .HasForeignKey(b => b.CompanyInformationID);

            modelBuilder.Entity<TbDepartment>()
                     .HasMany(c => c._TbCategory)
                     .WithOne(b => b._TbDepartment)
                     .HasForeignKey(b => b.DepartmentId)
                     .IsRequired(); // إضافة هذا السطر لتعيين إجبارية العلاقة

            modelBuilder.Entity<TbCategory>()
                     .HasMany(c => c._TbTool)
                     .WithOne(b => b._TbCategory)
                     .HasForeignKey(b => b.CategoryId)
                     .IsRequired();

            modelBuilder.Entity<TbTool>()
                     .HasMany(c => c._TbImageTool)
                     .WithOne(b => b._TbTool)
                     .HasForeignKey(b => b.ToolId);

            modelBuilder.Entity<TbAbout>()
                     .HasMany(c => c._TbTeam)
                     .WithOne(b => b._TbAbout)
                     .HasForeignKey(b => b.AboutId);

            modelBuilder.Entity<TbDealOfTheDay>()
                     .HasMany(c => c._TbTool)
                     .WithOne(b => b._TbDealOfTheDay)
                     .HasForeignKey(b => b.DealOfTheDayId);

            modelBuilder.Entity<TbNewArrivalProduct>()
                    .HasMany(c => c._TbTool)
                    .WithOne(b => b._TbNewArrivalProduct)
                    .HasForeignKey(b => b.NewArrivalProductId);

            modelBuilder.Entity<TbNumberOfPayment>()
                    .HasMany(c => c._TbTool)
                    .WithOne(b => b._TbNumberOfPayment)
                    .HasForeignKey(b => b.NumberOfPaymentId);
            /*
            // Seed data tables:
            modelBuilder.Entity<TbDepartment>().HasData(
                    new TbDepartment { DepartmentId = 1, DepartmentName = "Action", DepartmentCurrentState = 1 },
                    new TbDepartment { DepartmentId = 2, DepartmentName = "SciFi", DepartmentCurrentState = 2 },
                    new TbDepartment { DepartmentId = 3, DepartmentName = "History", DepartmentCurrentState = 3 },
                    new TbDepartment { DepartmentId = 4, DepartmentName = "Comedy", DepartmentCurrentState = 4 },
                    new TbDepartment { DepartmentId = 5, DepartmentName = "Drama", DepartmentCurrentState = 5 });

            modelBuilder.Entity<TbCategory>().HasData(
                    new TbCategory { CategoryId = 1, CategoryName = "Action", CategoryCurrentState = 1, DepartmentId = 1 },
                    new TbCategory { CategoryId = 2, CategoryName = "SciFi", CategoryCurrentState = 1, DepartmentId = 1 },
                    new TbCategory { CategoryId = 3, CategoryName = "History", CategoryCurrentState = 1, DepartmentId = 2 },
                    new TbCategory { CategoryId = 4, CategoryName = "Comedy", CategoryCurrentState = 1, DepartmentId = 2 },
                    new TbCategory { CategoryId = 5, CategoryName = "Drama", CategoryCurrentState = 1, DepartmentId = 3 });

            modelBuilder.Entity<TbTool>().HasData(
                    new TbTool { ToolId = 1, ToolName = "Hammer", ToolCurrentState = 1, ToolSticker = "A1", ToolDescription = "A heavy-duty hammer for construction work", ToolProductPrice = 10.99m, CategoryId = 1 },
                    new TbTool { ToolId = 2, ToolName = "Screwdriver", ToolCurrentState = 1, ToolSticker = "B1", ToolDescription = "A versatile screwdriver for various tasks", ToolProductPrice = 5.99m, CategoryId = 1 },
                    new TbTool { ToolId = 3, ToolName = "Telescope", ToolCurrentState = 1, ToolSticker = "C1", ToolDescription = "A powerful telescope for stargazing", ToolProductPrice = 99.99m, CategoryId = 2 },
                    new TbTool { ToolId = 4, ToolName = "Camera", ToolCurrentState = 1, ToolSticker = "D1", ToolDescription = "A high-resolution camera for capturing moments", ToolProductPrice = 199.99m, CategoryId = 2 },
                    new TbTool { ToolId = 5, ToolName = "Book", ToolCurrentState = 1, ToolSticker = "E1", ToolDescription = "An informative book on historical events", ToolProductPrice = 19.99m, CategoryId = 3 });
            modelBuilder.Entity<TbImageTool>().HasData(
                    new TbImageTool { ImageTool = 1, ToolProductImgPrimary = "image1.jpg", ToolProductImgSecondry = "image1_secondary.jpg", ImageCurrentState = 1, ToolId = 1 },
                    new TbImageTool { ImageTool = 2, ToolProductImgPrimary = "image2.jpg", ToolProductImgSecondry = "image2_secondary.jpg", ImageCurrentState = 1, ToolId = 1 },
                    new TbImageTool { ImageTool = 3, ToolProductImgPrimary = "image3.jpg", ToolProductImgSecondry = "image3_secondary.jpg", ImageCurrentState = 1, ToolId = 2 },
                    new TbImageTool { ImageTool = 4, ToolProductImgPrimary = "image4.jpg", ToolProductImgSecondry = "image4_secondary.jpg", ImageCurrentState = 1, ToolId = 3 },
                    new TbImageTool { ImageTool = 5, ToolProductImgPrimary = "image5.jpg", ToolProductImgSecondry = "image5_secondary.jpg", ImageCurrentState = 1, ToolId = 4 });
            modelBuilder.Entity<TbCompanyInformation>().HasData(
                    new TbCompanyInformation
                    {
                        CompanyInformationID = 1,
                        CompanyInformationName = "اسم الشركة",
                        CompanyInformationDescription = "وصف الشركة",
                        CompanyInformationAddress = "عنوان الشركة",
                        CompanyInformationPhone = "1234567890",
                        CompanyInformationEmail = "company@example.com",
                        CompanyInformationCurrentState = 1
                    });

            modelBuilder.Entity<TbLanguage>().HasData(
                new TbLanguage { LanguageId = 1, LanguageName = "عربي", LanguageCurrentState = 1, CompanyInformationID = 1 },
                new TbLanguage { LanguageId = 2, LanguageName = "English", LanguageCurrentState = 1, CompanyInformationID = 1 }
            );

            modelBuilder.Entity<TbCurrency>().HasData(
                new TbCurrency { CurrencyId = 1, CurrencyName = "SDG", CurrencyCurrentState = 1, CompanyInformationID = 1 },
                new TbCurrency { CurrencyId = 2, CurrencyName = "USD", CurrencyCurrentState = 1, CompanyInformationID = 1 },
                new TbCurrency { CurrencyId = 3, CurrencyName = "SAR", CurrencyCurrentState = 1, CompanyInformationID = 1 }
            );

            modelBuilder.Entity<TbAbout>().HasData(
                new TbAbout
                {
                    AboutId = 1,
                    AboutUsImg = "about_img.jpg",
                    AboutDescriptionImg = "about_description_img.jpg",
                    AboutTitelDescription = "عنوان الوصف",
                    AboutDescription = "وصف المعلومات عنا",
                    AboutHappyCustomer = 100,
                    AboutHoursWorked = 5000,
                    AboutAwardsWinned = 10,
                    AboutProjectDone = 50,
                    AboutCurrentState = 1
                }
            );

            modelBuilder.Entity<TbTeam>().HasData(
                new TbTeam { TeamId = 1, TeamName = "عضو الفريق 1", TeamTitle = "مسمى الفريق 1", TeamDescription = "وصف العضو 1", TeamImg = "team_img1.jpg", AboutId = 1 },
                new TbTeam { TeamId = 2, TeamName = "عضو الفريق 2", TeamTitle = "مسمى الفريق 2", TeamDescription = "وصف العضو 2", TeamImg = "team_img2.jpg", AboutId = 1 },
                new TbTeam { TeamId = 3, TeamName = "عضو الفريق 3", TeamTitle = "مسمى الفريق 3", TeamDescription = "وصف العضو 3", TeamImg = "team_img3.jpg", AboutId = 1 },
                new TbTeam { TeamId = 4, TeamName = "عضو الفريق 4", TeamTitle = "مسمى الفريق 4", TeamDescription = "وصف العضو 4", TeamImg = "team_img4.jpg", AboutId = 1 }
            );
            modelBuilder.Entity<TbTellUs>().HasData(
                new TbTellUs
                {
                    TellId = 1,
                    TellName = "اسمك",
                    TellEmail = "example@example.com",
                    TellSubject = "عنوان الرسالة",
                    TellMessage = "نص الرسالة",
                    TellCurrentState = 1
                }
            );*/
        }
    }
}
