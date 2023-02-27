using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoLocal;
        private readonly IRepositorioEquipo _repoVisitante;
        private readonly IRepositorioArbitro _repoArbitro;
        private readonly IRepositorioEstadio _repoEstadio;

        public Partido partido {get; set;}
        public SelectList EquipoLocalOptions { get; set; }
        public SelectList EquipoVisitanteOptions { get; set; }
        public SelectList ArbitroOptions { get; set; }
        public SelectList EstadioOptions {get;set;}
        public int EquipoLocalSelected { get; set; }
        public int EquipoVisitanteSelected { get; set; }
        public int ArbitroSelected { get; set; }
        public int EstadioSelected {get;set;}

        public EditModel(IRepositorioPartido repoPartido, IRepositorioEquipo
            repoLocal, IRepositorioEquipo repoVisitante, IRepositorioArbitro repoArbitro, IRepositorioEstadio repoEstadio)
        {
            _repoPartido = repoPartido;
            _repoLocal = repoLocal;
            _repoVisitante = repoVisitante;
            _repoArbitro = repoArbitro;
            _repoEstadio =repoEstadio;
        }

        public IActionResult OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            EquipoLocalOptions = new SelectList(_repoLocal.GetAllEquipos(), "Id", "Nombre");
            EquipoLocalSelected = partido.Local.Id;
            EquipoVisitanteOptions = new SelectList(_repoVisitante.GetAllEquipos(), "Id", "Nombre");
            EquipoVisitanteSelected = partido.Visitante.Id;
            ArbitroOptions = new SelectList(_repoArbitro.GetAllArbitros(), "Id", "Nombre");
            ArbitroSelected = partido.Arbitro.Id;
            EstadioOptions = new SelectList(_repoEstadio.GetAllEstadios(), "Id", "Nombre");
            EstadioSelected = partido.Estadio.Id;
            if (partido == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Partido partido, int idEquipoLocal, int idEquipoVisitante, int idArbitro, int idEstadio)
        {
            _repoPartido.UpdatePartido(partido, idEquipoLocal, idEquipoVisitante, idArbitro, idEstadio);
            return RedirectToPage("Index");
        }
    }
}
