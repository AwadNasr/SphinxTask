using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sphinx.Core;

namespace SphinxTask.Pages.Client
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Sphinx.Core.Entities.Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await unitOfWork.ClientRepository.GetByIdAsync(id);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Client != null)
            {
                await unitOfWork.ClientRepository.DeleteAsync(Client);
            }

            return RedirectToPage("./Index");
        }
    }
}
