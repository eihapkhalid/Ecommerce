using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IImageToolRepository : IRepository<TbImageTool>
    {
        void Update(TbImageTool obj);
    }
}
