using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioEstadio : IRepositorioEstadio
    {
        private readonly DataContext _dataContext = new DataContext();

        public Estadio AddEstadio(Estadio estadio)
        {
            var estadioInsertado = _dataContext.Estadios.Add(estadio);
            _dataContext.SaveChanges();
            return estadioInsertado.Entity;
        }

        public IEnumerable<Estadio> GetAllEstadios()
        {
            var estadios = _dataContext.Estadios
                            .Include(m => m.Partidos)
                            .ToList();

            return estadios;
        }

        public Estadio GetEstadio(int idEstadio)
        {
            var estadioEncontrado = _dataContext.Estadios.Find(idEstadio);
            return estadioEncontrado;
        }

        public Estadio UpdateEstadio(Estadio estadio)
        {
            var estadioEncontrado = GetEstadio(estadio.Id);
            estadioEncontrado.Nombre = estadio.Nombre;
            estadioEncontrado.Direccion = estadio.Direccion;
            estadioEncontrado.Ciudad = estadio.Ciudad;
            _dataContext.SaveChanges();
            return estadioEncontrado;
        }

        public Estadio DeleteEstadio(int idEstadio)
        {
            var estadioEncontrado = _dataContext.Estadios.Find(idEstadio);
            if (estadioEncontrado != null)
            {
                _dataContext.Estadios.Remove(estadioEncontrado);
                _dataContext.SaveChanges();
            }
            return estadioEncontrado;
        }
    }
}