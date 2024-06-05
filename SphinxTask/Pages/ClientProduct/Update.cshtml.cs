using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sphinx.Core;
using SphinxTask.ViewModels;

namespace SphinxTask.Pages.ClientProduct
{
    public class UpdateModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [BindProperty]
        public CreateClientProductVM ClientProduct { get; set; }
        public SelectList ActiveProducts { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var clientProduct = await unitOfWork.ClientProductsRepository.GetByIdAsync(id);
            if (clientProduct == null)
            {
                return NotFound("ClientProduct not found");
            }

            ClientProduct = new CreateClientProductVM
            {
                Id = clientProduct.Id,
                ClientId = clientProduct.ClientId,
                ProductId = clientProduct.ProductId,
                StartDate = clientProduct.StartDate,
                EndDate = clientProduct.EndDate,
                License = clientProduct.License
            };

            var products = await unitOfWork.ProductRepository.GetAllAsync();
            ActiveProducts = new SelectList(products.Where(p => p.IsActive), "Id", "Name", clientProduct.ProductId);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var products = await unitOfWork.ProductRepository.GetAllAsync();
                ActiveProducts = new SelectList(products.Where(p => p.IsActive), "Id", "Name", ClientProduct.ProductId);
                return Page();
            }

            var clientProduct = await unitOfWork.ClientProductsRepository.GetByIdAsync(ClientProduct.Id);
            if (clientProduct == null)
            {
                return NotFound("ClientProduct not found");
            }

            clientProduct.ProductId = ClientProduct.ProductId;
            clientProduct.StartDate = ClientProduct.StartDate;
            clientProduct.EndDate = ClientProduct.EndDate;
            clientProduct.License = ClientProduct.License;

            await unitOfWork.ClientProductsRepository.UpdateAsync(clientProduct);
            return RedirectToPage("/Client/Details", new { id = ClientProduct.ClientId });
        }


    }
}
