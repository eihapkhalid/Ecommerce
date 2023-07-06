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
        IAboutRepository AboutRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICompanyInformationRepository CompanyInformationRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IImageToolRepository ImageToolRepository { get; }
        ILanguageRepository LanguageRepository { get; }
        ITeamRepository TeamsRepository { get; }
        IToolRepository ToolRepository { get; }
        ITellUsRepository TellUsRepository { get; }
    }
}
