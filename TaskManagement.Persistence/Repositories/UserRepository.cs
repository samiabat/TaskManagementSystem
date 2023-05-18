using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagemnt.Domain;
using TaskManagment.Application.Contracts.Persistence;

namespace TaskManagement.Persistence.Repositories
{
    public class UserRepository: GenericRepositiory<User>, IUserRepository
    {
        public UserRepository(TaskManagementDBContext taskManagementDBContext): base(taskManagementDBContext)
        {
            
        }
    }
}
