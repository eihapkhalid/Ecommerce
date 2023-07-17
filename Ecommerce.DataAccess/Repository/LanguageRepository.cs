using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository
{
    public class LanguageRepository : Repository<TbLanguage>, ILanguageRepository
    {
        #region dependency injection
        private ApplicationDbContext _db;
        public LanguageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        #endregion

        #region Update
        public void Update(TbLanguage obj)
        {
            _db.TbLanguages.Update(obj);
        } 
        #endregion
    }
}
