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
