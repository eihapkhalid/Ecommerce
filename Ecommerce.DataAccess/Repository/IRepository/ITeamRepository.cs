using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface ITeamRepository : IRepository<TbTeam>
    {
        void Update(TbTeam obj);
    }
}
