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
    public class ClientProductsRepository : GenericRepository<ClientProducts>, IClientProductsRepository
    {
        private readonly SphinxContext context;
        public ClientProductsRepository(SphinxContext _context) : base(_context)
        {
            context = _context;
        }
        public async Task<IReadOnlyList<ClientProducts>> GetClientWithProducts(int id)
        {
            return await context.ClientProducts.Where(cp => cp.ClientId==id)
                .Include(cp => cp.Product)
                .OrderBy(cp => cp.Product.Name)
                .ToListAsync();
        }
    }
}
