using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx.Core.Entities;
using Sphinx.Core;

namespace SphinxTask.Pages.Client
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IReadOnlyList<Sphinx.Core.Entities.Client> Clients { get; set; }
        public async Task OnGetAsync()
        {
            Clients= await unitOfWork.ClientRepository.GetAllClientsWithSorting();
        }
    }
}
