using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sphinx.Core;
using SphinxTask.ViewModels;

namespace SphinxTask.Pages.ClientProduct
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [BindProperty]
        public CreateClientProductVM ClientProduct { get; set; }
        public SelectList ActiveProducts { get; set; }

        public async Task<IActionResult> OnGetAsync(int clientId)
        {
            var client = await unitOfWork.ClientRepository.GetByIdAsync(clientId);
            if (client == null)
            {
                return NotFound($"Client not found{clientId}");
            }
            ClientProduct = new CreateClientProductVM
            {
                ClientId = clientId
            };
            var products = await unitOfWork.ProductRepository.GetAllAsync();
            ActiveProducts = new SelectList(products.Where(p => p.IsActive), "Id", "Name");

            if (ActiveProducts.Count() == 0)
            {
                TempData["Count"] = "There is no active products to add";
                return RedirectToPage("/Client/Index", new { id = clientId});
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var products = await unitOfWork.ProductRepository.GetAllAsync();
                ActiveProducts = new SelectList(products.Where(p => p.IsActive), "Id", "Name");
                return Page();
            }
            var clientProduct = new Sphinx.Core.Entities.ClientProducts
            {
                ClientId = ClientProduct.ClientId,
                ProductId = ClientProduct.ProductId,
                StartDate = ClientProduct.StartDate,
                EndDate = ClientProduct.EndDate,
                License = ClientProduct.License
            };

            await unitOfWork.ClientProductsRepository.AddAsync(clientProduct);
            return RedirectToPage("/Client/Details", new { id = ClientProduct.ClientId });
        }

    }
}
