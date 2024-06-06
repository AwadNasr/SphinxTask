using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sphinx.Core;
using Sphinx.Core.Entities;
using SphinxTask.ViewModels;

namespace SphinxTask.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<CreateProductVM> Products { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public async Task<IActionResult> OnGetAsync(int? pageNumber)
        {
            CurrentPage = pageNumber ?? 1;
            int pageSize = 3;
            var products = await unitOfWork.ProductRepository.GetAllProductsWithSorting(CurrentPage, pageSize);
            Products = products.Select(prod => new CreateProductVM
            {
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                IsActive = prod.IsActive,
            }).ToList();
            var totalItems = await unitOfWork.ProductRepository.GetAllAsync();
            var totalProducts = totalItems.Count();
            TotalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
            return Page();
        }
    }
}
