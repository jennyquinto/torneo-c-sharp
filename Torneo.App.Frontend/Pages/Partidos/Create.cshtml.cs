using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoLocal;
        private readonly IRepositorioEquipo _repoVisitante;
        private readonly IRepositorioArbitro _repoArbitro;
        private readonly IRepositorioEstadio _repoEstadio;

        public Partido partido {get; set;}
        public IEnumerable<Equipo> local {get;set;}
        public IEnumerable<Equipo> visitante {get;set;}
        public IEnumerable<Arbitro> arbitros {get;set;}
        public IEnumerable<Estadio> estadios {get;set;}


        public CreateModel(IRepositorioPartido repoPartido, IRepositorioEquipo
            repoLocal, IRepositorioEquipo repoVisitante, IRepositorioArbitro repoArbitro, IRepositorioEstadio repoEstadio)
            {
                _repoPartido = repoPartido;
                _repoLocal = repoLocal;
                _repoVisitante = repoVisitante;
                _repoArbitro = repoArbitro;
                _repoEstadio = repoEstadio;
            }

        public void OnGet()
        {
            partido = new Partido();
            local = _repoLocal.GetAllEquipos();
            visitante = _repoVisitante.GetAllEquipos();
            arbitros = _repoArbitro.GetAllArbitros();
            estadios = _repoEstadio.GetAllEstadios();
        }

        public IActionResult OnPost(Partido partido, int idEquipoLocal, int idEquipoVisitante, int idArbitro, int idEstadio)
        {
//          if (ModelState.IsValid)
//          {
                _repoPartido.AddPartido(partido, idEquipoLocal, idEquipoVisitante, idArbitro, idEstadio);
                return RedirectToPage("Index");
/*          }
            else{
                
                local = _repoLocal.GetAllEquipos();
                visitante = _repoVisitante.GetAllEquipos();
                arbitros = _repoArbitro.GetAllArbitros();
                return Page();
            }
*/
        }
    }
}
