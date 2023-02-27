using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioEstadio
    {
        public Estadio AddEstadio(Estadio estadio);
        public IEnumerable<Estadio> GetAllEstadios();
        public Estadio GetEstadio(int idEstado);
        public Estadio UpdateEstadio(Estadio estadio);
        public Estadio DeleteEstadio(int idEstadio);
    }
}