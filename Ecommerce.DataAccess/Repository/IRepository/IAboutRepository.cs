using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IAboutRepository : IRepository<TbAbout>
    {
        void Update(TbAbout obj);
    }
}
