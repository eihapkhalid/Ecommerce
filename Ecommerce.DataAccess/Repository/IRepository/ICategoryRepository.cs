using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<TbCategory>
    {
        void Update(TbCategory obj);
    }
}
