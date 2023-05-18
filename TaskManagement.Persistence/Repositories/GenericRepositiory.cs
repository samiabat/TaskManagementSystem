using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Application.Contracts.Persistence;

namespace TaskManagement.Persistence.Repositories
{
    public class GenericRepositiory<T> : IGenericRepository<T> where T : class
    {
        private readonly TaskManagementDBContext _dbcontext;

        public GenericRepositiory(TaskManagementDBContext taskManagementDbContext)
        {
            _dbcontext = taskManagementDbContext;
        }


        public async Task<T> Add(T entity)
        {
            await _dbcontext.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int Id)
        {
            return await _dbcontext.Set<T>().FindAsync(Id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }
    }
}
