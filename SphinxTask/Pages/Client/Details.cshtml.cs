using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sphinx.Core;
using Sphinx.Core.Entities;
namespace SphinxTask.Pages.Client
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Sphinx.Core.Entities.Client Client { get; set; }
        public IReadOnlyList<Sphinx.Core.Entities.ClientProducts> ClientProducts { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Client = await unitOfWork.ClientRepository.GetByIdAsync(id);

            if (Client == null) { 
                return NotFound();
            }
            ClientProducts = await unitOfWork.ClientProductsRepository.GetClientWithProducts(Client.Id);
            return Page();

        }
    }
}
