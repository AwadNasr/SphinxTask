using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx.Core;
using SphinxTask.ViewModels;

namespace SphinxTask.Pages.Product
{
    public class UpdateModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [BindProperty]
        public CreateProductVM Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MappedProduct = await unitOfWork.ProductRepository.GetByIdAsync(id);

            if (MappedProduct == null)
            {
                return NotFound();
            }
            Product = new CreateProductVM
            {
                Id = MappedProduct.Id,
                Name = MappedProduct.Name,
                Description= MappedProduct.Description,
                IsActive = MappedProduct.IsActive,
               
            };
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var productEntity = await unitOfWork.ProductRepository.GetByIdAsync(Product.Id);

            if (productEntity == null)
            {
                return NotFound();
            }

            productEntity.Name = Product.Name;
            productEntity.Description = Product.Description;
            productEntity.IsActive = Product.IsActive;
           

            await unitOfWork.ProductRepository.UpdateAsync(productEntity);

            return RedirectToPage("./Index");
        }
    }
}
