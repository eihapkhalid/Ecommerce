using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        void Save();
        public IAboutRepository TbAbout { get; }
        public ICategoryRepository TbCategory { get; }
        public ICompanyInformationRepository TbCompanyInformation { get;}
        public ICurrencyRepository TbCurrency { get; }
        public IDepartmentRepository TbDepartment { get; }
        public IImageToolRepository TbImageTool { get; }
        public ILanguageRepository TbLanguage { get; }
        public ITeamRepository TbTeams { get; }
        public IToolRepository TbTool { get; }
        public ITellUsRepository TbTellUs { get; }
    }
}
