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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly SphinxContext context;
        public ProductRepository(SphinxContext _context) : base(_context)
        {
            context= _context;
        }

        public async Task<IReadOnlyList<Product>> GetAllProductsWithSorting(int pageNumber, int pageSize)
        {
            return await context.Products.OrderBy(p => p.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
