using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Posiciones
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioPosicion _repoPosicion;
        public Posicion posicion { get; set; }

        public EditModel(IRepositorioPosicion repoPosicion)
        {
            _repoPosicion = repoPosicion;
        }

        public IActionResult OnGet(int id)
        {
            posicion = _repoPosicion.GetPosicion(id);
            if (posicion == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Posicion posicion)
        {
            _repoPosicion.UpdatePosicion(posicion);
            return RedirectToPage("Index");
        }
    }
}
