using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sphinx.Core;
using SphinxTask.ViewModels;

namespace SphinxTask.Pages.Client
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public CreateClientVM Client { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var codeExist= await IsCodeExist(Client.Code);
            if (codeExist == true)
            {
                ViewData["msg"] = "Code is Found before";
                return Page();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var Clientdb = new Sphinx.Core.Entities.Client()
            {
                Name = Client.Name,
                Code = Client.Code,
                Class = Client.Class,
                State = Client.State,
            };

            await unitOfWork.ClientRepository.AddAsync(Clientdb);

            return RedirectToPage("./Index");
        }

        public async Task<bool>  IsCodeExist(long code)
        {
            var clients = await unitOfWork.ClientRepository.GetAllAsync();
            foreach (var client in clients)
            {
                if (client.Code == code)
                {
                    return true;
                }
            }
            return false;
            
        }


    }
}
