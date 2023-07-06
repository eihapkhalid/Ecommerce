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
    public class TellUsRepository : Repository<TbTellUs>, ITellUsRepository
    {
        #region dependency injection
        private ApplicationDbContext _db;
        public TellUsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        #endregion

        #region Update
        public void Update(TbTellUs obj)
        {
            _db.TbTellUss.Update(obj);
        } 
        #endregion
    }
}
