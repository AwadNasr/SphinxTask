using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx.Core;
using Sphinx.Core.Entities;
using SphinxTask.ViewModels;

namespace SphinxTask.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public CreateProductVM Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            Product = new CreateProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                IsActive = product.IsActive
            };
            return Page();
        }

    }
}
