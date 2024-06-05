using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx.Core;
using Sphinx.Core.Entities;

namespace SphinxTask.Pages.ClientProduct
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Sphinx.Core.Entities.ClientProducts ClientProducts { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClientProducts = await unitOfWork.ClientProductsRepository.GetByIdAsync(id);

            if (ClientProducts == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ClientProducts != null)
            {
                await unitOfWork.ClientProductsRepository.DeleteAsync(ClientProducts);
            }

            return RedirectToPage("/Client/Details", new { id = ClientProducts.ClientId });
        }
    }
}
