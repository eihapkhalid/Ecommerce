using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository
{
    public class ImageToolRepository : Repository<TbImageTool>, IImageToolRepository
    {
        #region dependency injection
        private ApplicationDbContext _db;
        public ImageToolRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        #endregion

        #region Update
        public void Update(TbImageTool obj)
        {
            _db.TbImageTools.Update(obj);
        } 
        #endregion
    }
}
