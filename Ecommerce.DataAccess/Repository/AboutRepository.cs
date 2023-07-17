using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository
{
    public class AboutRepository : Repository<TbAbout>, IAboutRepository
    {
        #region dependency injection
        private ApplicationDbContext _db;
        public AboutRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        #endregion

        #region Update
        public void Update(TbAbout obj)
        {
            _db.TbAbouts.Update(obj);
        } 
        #endregion
    }
}
