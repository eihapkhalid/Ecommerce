using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository
{
    public class TeamRepository : Repository<TbTeam>, ITeamRepository
    {
        #region dependency injection
        private ApplicationDbContext _db;
        public TeamRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        #endregion

        #region Update
        public void Update(TbTeam obj)
        {
            _db.TbTeams.Update(obj);
        } 
        #endregion
    }
}
