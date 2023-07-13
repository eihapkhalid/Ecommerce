using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        #region dependency injection
        private ApplicationDbContext _db;
        public IAboutRepository TbAbout { get; private set; }
        public ICategoryRepository TbCategory { get; private set; }
        public ICompanyInformationRepository TbCompanyInformation { get; private set; }
        public ICurrencyRepository TbCurrency { get; private set; }
        public IDepartmentRepository TbDepartment { get; private set; }
        public IImageToolRepository TbImageTool { get; private set; }
        public ILanguageRepository TbLanguage { get; private set; }
        public ITeamRepository TbTeams { get; private set; }
        public IToolRepository TbTool { get; private set; }
        public ITellUsRepository TbTellUs { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            TbAbout = new AboutRepository(_db);
            TbCategory = new CategoryRepository(_db);
            TbCompanyInformation = new CompanyInformationRepository(_db);
            TbCurrency = new CurrencyRepository(_db);
            TbDepartment = new DepartmentRepository(_db);
            TbImageTool = new ImageToolRepository(_db);
            TbLanguage = new LanguageRepository(_db);
            TbTeams = new TeamRepository(_db);
            TbTool = new ToolRepository(_db);
            TbTellUs = new TellUsRepository(_db);
        }
        #endregion

        #region Save
        public void Save()
        {
            try
            {
                int savedChanges = _db.SaveChanges();
                if (savedChanges > 0)
                {
                    Console.WriteLine("Data saved successfully. Number of affected rows: " + savedChanges);

                }
                else
                {
                    Console.WriteLine("No data changes to save.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving data to the database: " + ex.Message);
                // يمكنك التعامل مع الاستثناء هنا، مثلاً طباعة رسالة الخطأ أو تسجيلها
            }
        } 
        #endregion

    }
}
