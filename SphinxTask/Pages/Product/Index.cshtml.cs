using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sphinx.Core;

namespace SphinxTask.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IReadOnlyList<Sphinx.Core.Entities.Product> Products { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public async Task<IActionResult> OnGetAsync(int? pageNumber)
        {
            CurrentPage = pageNumber ?? 1;
            int pageSize = 5;
            Products = await unitOfWork.ProductRepository.GetAllProductsWithSorting(CurrentPage, pageSize);
            var totalItems = await unitOfWork.ProductRepository.GetAllAsync();
            var totalProducts = totalItems.Count();
            TotalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
            return Page();
        }
    }
}
