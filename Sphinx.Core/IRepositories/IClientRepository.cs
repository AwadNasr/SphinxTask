using Sphinx.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphinx.Core.Repositories
{
    public interface IClientRepository :  IGenericRepository<Client>
    {
        Task<IReadOnlyList<Client>> GetAllClientsWithSorting();
        
    }
}
