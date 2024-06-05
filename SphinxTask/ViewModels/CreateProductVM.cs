using Sphinx.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace SphinxTask.ViewModels
{
    public class CreateProductVM : BaseEntity
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
