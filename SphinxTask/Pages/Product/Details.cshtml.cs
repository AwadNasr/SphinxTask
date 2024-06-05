using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx.Core;

namespace SphinxTask.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
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

    }
}
