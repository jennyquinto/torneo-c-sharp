using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly DataContext _dataContext = new DataContext();

        public Partido AddPartido(Partido partido, int idEquipoLocal, int idEquipoVisitante, int idArbitro, int idEstadio)
        {
            var equipoLocalEncontrado = _dataContext.Equipos.Find(idEquipoLocal);
            var equipoVisitanteEncontrado = _dataContext.Equipos.Find(idEquipoVisitante);
            var arbitroEncontrado = _dataContext.Arbitros.Find(idArbitro);
            var estadioEncontrado = _dataContext.Estadios.Find(idEstadio);
            partido.Local = equipoLocalEncontrado;
            partido.Visitante = equipoVisitanteEncontrado;
            partido.Arbitro = arbitroEncontrado;
            partido.Estadio = estadioEncontrado;
            var partidoInsertado = _dataContext.Partidos.Add(partido);
            _dataContext.SaveChanges();
            return partidoInsertado.Entity;
        }
        public IEnumerable<Partido> GetAllPartidos()
        {
            var partidos = _dataContext.Partidos
                            .Include(e => e.Local)
                            .Include(e => e.Visitante)
                            .Include(e => e.Arbitro)
                            .Include(e => e.Estadio)
                            .ToList();
            return partidos;
        }

        public Partido GetPartido(int idPartido)
        {
            var partidoEncontrado = _dataContext.Partidos
            .Where(e => e.Id == idPartido)
            .Include(e => e.Local)
            .Include(e => e.Visitante)
            .Include(e => e.Arbitro)
            .Include(e => e.Estadio)
            .FirstOrDefault();
            return partidoEncontrado;
        }

        public Partido UpdatePartido(Partido partido, int idEquipoLocal, int idEquipoVisitante, int idArbitro, int idEstadio)
        {
            var partidoEncontrado =GetPartido(partido.Id);
            var equipoLocalEncontrado = _dataContext.Equipos.Find(idEquipoLocal);
            var equipoVisitanteEncontrado = _dataContext.Equipos.Find(idEquipoVisitante);
            var arbitroEncontrado = _dataContext.Arbitros.Find(idArbitro);
            var estadioEncontrado = _dataContext.Estadios.Find(idEstadio);
            partidoEncontrado.FechaHora = partido.FechaHora;
            partidoEncontrado.Local = equipoLocalEncontrado;
            partidoEncontrado.Visitante = equipoVisitanteEncontrado;
            partidoEncontrado.Arbitro = arbitroEncontrado;
            partidoEncontrado.Estadio = estadioEncontrado;
            _dataContext.SaveChanges();
            return partidoEncontrado;
        }

        public Partido DeletePartido(int idPartido)
        {
            var partidoEncontrado = _dataContext.Partidos.Find(idPartido);
            if (partidoEncontrado != null)
            {
                _dataContext.Partidos.Remove(partidoEncontrado);
                _dataContext.SaveChanges();
            }
            return partidoEncontrado;
        }
    }
}