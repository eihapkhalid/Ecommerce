using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface ILanguageRepository : IRepository<TbLanguage>
    {
        void Update(TbLanguage obj);
    }
}
