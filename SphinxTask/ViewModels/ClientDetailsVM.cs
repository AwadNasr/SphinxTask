using Sphinx.Core.Entities;
using Sphinx.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SphinxTask.ViewModels
{
    public class ClientDetailsVM
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public long Code { get; set; }
        public ClientClass Class { get; set; }
        public ClientState State { get; set; }
        public List<ClientProductVM> ClientProducts { get; set; }
    }
}
