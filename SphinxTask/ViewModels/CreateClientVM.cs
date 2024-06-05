using Sphinx.Core.Entities;
using Sphinx.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SphinxTask.ViewModels
{
    public class CreateClientVM : BaseEntity
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(1, 999999999, ErrorMessage = "Code must be numeric and 9 numbers maximum and unique.")]
        public long Code { get; set; }

        [Required]
        public ClientClass Class { get; set; }

        [Required]
        public ClientState State { get; set; }
    }
}
