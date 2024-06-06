using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sphinx.Core;
using Sphinx.Core.Entities;
using Sphinx.Repository;
using SphinxTask.ViewModels;
namespace SphinxTask.Pages.Client
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ClientDetailsVM Client { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var client = await unitOfWork.ClientRepository.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            var clientProducts = await unitOfWork.ClientProductsRepository.GetClientWithProducts(client.Id);

            Client = new ClientDetailsVM
            {
                Id = client.Id,
                Name = client.Name,
                Code = client.Code,
                Class = client.Class,
                State = client.State,
                ClientProducts = clientProducts.Select(cp => new ClientProductVM
                {
                    Id = cp.Id,
                    ProductName = cp.Product.Name,
                    StartDate = cp.StartDate,
                    EndDate = cp.EndDate,
                    License = cp.License
                }).OrderBy(cp => cp.ProductName).ToList()
            };

            return Page();
        }
    }
}
