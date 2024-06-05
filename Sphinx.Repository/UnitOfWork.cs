using Sphinx.Core;
using Sphinx.Core.Repositories;
using Sphinx.Repository.Data;
using Sphinx.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphinx.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SphinxContext context;
        public IClientRepository ClientRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IClientProductsRepository ClientProductsRepository { get; set; }


        public UnitOfWork(SphinxContext context)
        {
            ClientRepository = new ClientRepository(context);
            ProductRepository = new ProductRepository(context);
            ClientProductsRepository = new ClientProductsRepository(context);
        }
    }
}
