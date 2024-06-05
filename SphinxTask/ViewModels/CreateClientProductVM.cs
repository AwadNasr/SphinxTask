using Sphinx.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace SphinxTask.ViewModels
{
    public class CreateClientProductVM :BaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string License { get; set; }

        public int ClientId { get; set; }
        
        public int ProductId { get; set; }
        
    }
}
