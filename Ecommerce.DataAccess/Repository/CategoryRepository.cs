using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository
{
    public class CategoryRepository : Repository<TbCategory>, ICategoryRepository
    {
        #region dependency injection
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        #endregion

        #region Update
        public void Update(TbCategory obj)
        {
            _db.TbCategorys.Update(obj);
        } 
        #endregion
    }
}
