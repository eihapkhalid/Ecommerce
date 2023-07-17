using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository
{
    public class CompanyInformationRepository : Repository<TbCompanyInformation>, ICompanyInformationRepository
    {
        #region dependency injection
        private ApplicationDbContext _db;
        public CompanyInformationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        #endregion

        #region Update
        public void Update(TbCompanyInformation obj)
        {
            _db.TbCompanyInformations.Update(obj);
        } 
        #endregion
    }
}
