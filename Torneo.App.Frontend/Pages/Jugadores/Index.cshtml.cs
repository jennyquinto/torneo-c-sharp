using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Torneo.App.Persistencia;
using Torneo.App.Dominio;

namespace Torneo.App.Frontend.Pages.Jugadores
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioJugador _repoJugador;
        private readonly IRepositorioEquipo _repoEquipo;
        public IEnumerable<Jugador> jugadores { get; set; }

        public SelectList EquipoOptions { get; set; }
        public int EquipoSelected { get; set; }

        public bool ErrorEliminar {get;set;}

        public IndexModel(IRepositorioJugador repoJugador, IRepositorioEquipo repoEquipo)
        {
            _repoJugador = repoJugador;
            _repoEquipo = repoEquipo;
        }

        public void OnGet()
        {
            EquipoOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            jugadores = _repoJugador.GetAllJugadores();
            EquipoSelected = -1;
            ErrorEliminar = false;
        }

        public IActionResult OnPostDelete(int id)
        {
            try
            {
                _repoJugador.DeleteJugador(id);
                jugadores = _repoJugador.GetAllJugadores();
                return Page();
            }
            catch (Exception ex)
            {
                jugadores = _repoJugador.GetAllJugadores();
                ErrorEliminar = true;
                return Page();
            }
        }

        public void OnPostFiltro(int idEquipo)
        {
            EquipoOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            if (idEquipo != -1)
            {
                EquipoSelected = idEquipo;
                jugadores = _repoJugador.GetJugadoresEquipo(EquipoSelected);
            }
            else
            {
                jugadores = _repoJugador.GetAllJugadores();
                EquipoSelected = -1;
            }
        }
    }
}

