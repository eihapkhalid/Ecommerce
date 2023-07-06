using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                     .HasForeignKey(b => b.DepartmentId);

            modelBuilder.Entity<TbCategory>()
                     .HasMany(c => c._TbTool)
                     .WithOne(b => b._TbCategory)
                     .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<TbTool>()
                     .HasMany(c => c._TbImageTool)
                     .WithOne(b => b._TbTool)
                     .HasForeignKey(b => b.ToolId);

            modelBuilder.Entity<TbAbout>()
                     .HasMany(c => c._TbTeam)
                     .WithOne(b => b._TbAbout)
                     .HasForeignKey(b => b.AboutId);
        }
    }
}
