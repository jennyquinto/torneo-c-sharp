using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Persistencia;
using Torneo.App.Dominio;

namespace Torneo.App.Frontend.Pages.Estadios
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        public IEnumerable<Estadio> estadios { get; set; }

        public bool ErrorEliminar {get;set;}

        public IndexModel(IRepositorioEstadio repoEstadio)
        {
            _repoEstadio = repoEstadio;
        }

        public void OnGet()
        {
            estadios = _repoEstadio.GetAllEstadios();
            ErrorEliminar = false;
        }

        public IActionResult OnPostDelete(int id)
        {
            try
            {
                _repoEstadio.DeleteEstadio(id);
                estadios = _repoEstadio.GetAllEstadios();
                return Page();
            }
            catch (Exception ex)
            {
                estadios = _repoEstadio.GetAllEstadios();
                ErrorEliminar = true;
                return Page();
            }
        }
    }
}
