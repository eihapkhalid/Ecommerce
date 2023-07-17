using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface ICompanyInformationRepository : IRepository<TbCompanyInformation>
    {
        void Update(TbCompanyInformation obj);
    }
}
