using Sphinx.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sphinx.Core.Entities
{
    public class Client :BaseEntity
    {
        public string Name { get; set; }
        public long Code { get; set; }
        public ClientClass Class { get; set; }
        public ClientState State { get; set; }
        // navigational property => Many
        public ICollection<ClientProducts> ClientProducts { get; set; } = new HashSet<ClientProducts>();

    }
}
