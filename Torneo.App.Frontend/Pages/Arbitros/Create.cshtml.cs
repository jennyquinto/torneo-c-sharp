using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.PagesArbitros
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioArbitro _repoArbitro;
        public Arbitro arbitro {get; set;}

        public CreateModel(IRepositorioArbitro repoArbitro)
        {
            _repoArbitro = repoArbitro;
        }

        public void OnGet()
        {
            arbitro = new Arbitro();
        }

        public IActionResult OnPost(Arbitro arbitro)
        {
            if(ModelState.IsValid)
            {
                _repoArbitro.AddArbitro(arbitro);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
