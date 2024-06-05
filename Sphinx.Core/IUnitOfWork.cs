using Sphinx.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphinx.Core
{
    public interface IUnitOfWork
    {
        public IClientRepository ClientRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IClientProductsRepository ClientProductsRepository { get; set; }

    }
}
