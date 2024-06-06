using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx.Core.Entities;
using Sphinx.Core;
using SphinxTask.ViewModels;

namespace SphinxTask.Pages.Client
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<CreateClientVM> Clients { get; set; }
        public async Task OnGetAsync()
        {
            var clients = await unitOfWork.ClientRepository.GetAllClientsWithSorting();
            Clients = clients.Select(client => new CreateClientVM
            {
                Id = client.Id,
                Name = client.Name,
                Code = client.Code,
                Class = client.Class,
                State = client.State
            }).ToList();
        }
    }
}
