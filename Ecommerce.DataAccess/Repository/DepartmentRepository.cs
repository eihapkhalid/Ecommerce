using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository
{
    public class DepartmentRepository : Repository<TbDepartment>, IDepartmentRepository
    {
        #region dependency injection
        private ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        #endregion

        #region Update
        public void Update(TbDepartment obj)
        {
            _db.TbDepartments.Update(obj);
        } 
        #endregion
    }
}
