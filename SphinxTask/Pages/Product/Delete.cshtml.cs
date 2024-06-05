using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx.Core;

namespace SphinxTask.Pages.Product
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Sphinx.Core.Entities.Product Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await unitOfWork.ProductRepository.GetByIdAsync(id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Product != null)
            {
                await unitOfWork.ProductRepository.DeleteAsync(Product);
            }

            return RedirectToPage("./Index");
        }

    }
}
