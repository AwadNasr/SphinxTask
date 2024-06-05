using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphinx.Core.Entities
{
    public class ClientProducts : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string License { get; set; }
        public int ClientId { get; set; }
        // navigational property 
        public Client Client { get; set; } 
        public int ProductId { get; set; }
        // navigational property 
        public Product Product { get; set; }
    }
}
