using Microsoft.EntityFrameworkCore;
using Sphinx.Core.Entities;
using Sphinx.Core.Repositories;
using Sphinx.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphinx.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public readonly SphinxContext context;
        public GenericRepository(SphinxContext _context)
        {
            context = _context;
        }
        public async Task<int> AddAsync(T obj)
        {
            await context.Set<T>().AddAsync(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T obj)
        {
            context.Set<T>().Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await context.Set<T>().FindAsync(id);
        }

        public async Task<int> UpdateAsync(T obj)
        {
            context.Set<T>().Update(obj);
            return await context.SaveChangesAsync();
        }
    }
}
