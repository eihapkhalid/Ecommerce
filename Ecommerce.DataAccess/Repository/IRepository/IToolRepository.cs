using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IToolRepository : IRepository<TbTool>
    {
        void Update(TbTool obj);
    }
}
