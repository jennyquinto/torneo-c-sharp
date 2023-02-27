using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioPartido
    {
        public Partido AddPartido(Partido partido, int idEquipoLocal, int idEquipoVisitante, int idArbitro, int idEstadio);
        public IEnumerable<Partido> GetAllPartidos();
        public Partido GetPartido(int idPartido);
        public Partido UpdatePartido(Partido partido, int idEquipoLocal, int idEquipoVisitante, int idArbitro, int idEstadio);
        public Partido DeletePartido(int idPartido);
    }
}