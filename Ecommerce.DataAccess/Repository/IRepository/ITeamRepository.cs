using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface ITeamRepository : IRepository<TbTeam>
    {
        void Update(TbTeam obj);
    }
}
