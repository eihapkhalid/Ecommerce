using Ecommerce.Models;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IDepartmentRepository : IRepository<TbDepartment>
    {
        void Update(TbDepartment obj);
    }
}
