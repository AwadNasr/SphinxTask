using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sphinx.Core;
using SphinxTask.ViewModels;

namespace SphinxTask.Pages.Client
{
    public class UpdateModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [BindProperty]
        public CreateClientVM Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MappedClient = await unitOfWork.ClientRepository.GetByIdAsync(id);

            if (MappedClient == null)
            {
                return NotFound();
            }
            Client = new CreateClientVM
            {
                Id = MappedClient.Id,
                Name = MappedClient.Name,
                Code = MappedClient.Code,
                Class = MappedClient.Class,
                State = MappedClient.State
            };
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var clientEntity = await unitOfWork.ClientRepository.GetByIdAsync(Client.Id);

            if (clientEntity == null)
            {
                return NotFound();
            }

            clientEntity.Name = Client.Name;
            clientEntity.Code = Client.Code;
            clientEntity.Class = Client.Class;
            clientEntity.State = Client.State;

            await unitOfWork.ClientRepository.UpdateAsync(clientEntity);

            return RedirectToPage("./Index");
        }
    }
}
