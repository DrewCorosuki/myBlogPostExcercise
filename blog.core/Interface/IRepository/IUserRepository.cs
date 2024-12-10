using blog.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Interface.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
