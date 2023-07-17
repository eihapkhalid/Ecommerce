using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface ITellUsRepository : IRepository<TbTellUs>
    {
        void Update(TbTellUs obj);
    }
}
