using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository
{
    public class CurrencyRepository : Repository<TbCurrency>, ICurrencyRepository
    {
        #region dependency injection
        private ApplicationDbContext _db;
        public CurrencyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        #endregion

        #region Update
        public void Update(TbCurrency obj)
        {
            _db.TbCurrencys.Update(obj);
        } 
        #endregion
    }
}
