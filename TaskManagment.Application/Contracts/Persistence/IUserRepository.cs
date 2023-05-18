using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagemnt.Domain;

namespace TaskManagment.Application.Contracts.Persistence
{
    public interface IUserRepository: IGenericRepository<User>
    {
    }
}
