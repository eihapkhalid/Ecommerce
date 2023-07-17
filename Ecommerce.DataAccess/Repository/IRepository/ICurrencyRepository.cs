using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface ICurrencyRepository : IRepository<TbCurrency>
    {
        void Update(TbCurrency obj);
    }
}
