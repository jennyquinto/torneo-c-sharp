using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Estadios
{
    public class CreateModel : PageModel
    {   
        private readonly IRepositorioEstadio _repoEstadio;

        public Estadio estadio {get;set;}

        public CreateModel(IRepositorioEstadio repoEstadio)
            {
                _repoEstadio = repoEstadio;
            }

        public void OnGet()
        {
            estadio = new Estadio();
        }

        public IActionResult OnPost(Estadio estadio)
        {
//         if (ModelState.IsValid)
//            {
                _repoEstadio.AddEstadio(estadio);
                return RedirectToPage("Index");
/*           }
            else
            {
                
                partidos = _repoPartido.GetAllPartidos();
                return Page();
            }
*/             
        }
    }
}
