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
