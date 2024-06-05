using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx.Core;
using SphinxTask.ViewModels;

namespace SphinxTask.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public CreateProductVM Product { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var Productdb = new Sphinx.Core.Entities.Product()
            {
                Name = Product.Name,
                Description = Product.Description,
                IsActive = Product.IsActive,
            };

            await unitOfWork.ProductRepository.AddAsync(Productdb);

            return RedirectToPage("./Index");
        }
    }
}
