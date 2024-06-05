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
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly SphinxContext context;
        public ClientRepository(SphinxContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<IReadOnlyList<Client>> GetAllClientsWithSorting()
        {
            return await context.Clients.OrderBy(c => c.Code).ToListAsync();
        }

        
    }
}
