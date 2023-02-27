using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPosicion : IRepositorioPosicion
    {
        private readonly DataContext _dataContext = new DataContext();

        public Posicion AddPosicion(Posicion posicion)
        {
            var posicionInsertada = _dataContext.Posiciones.Add(posicion);
            _dataContext.SaveChanges();
            return posicionInsertada.Entity;
        }
    
        public IEnumerable<Posicion> GetAllPosiciones()
        {
            var posiciones = _dataContext.Posiciones
                            .Include(e => e.Jugadores)
                            .ToList();
            return posiciones;
        }

        public Posicion GetPosicion(int idPosicion)
        {
            var posicionEncontrada = _dataContext.Posiciones.Find(idPosicion);
            return posicionEncontrada;
        }
        
        public Posicion UpdatePosicion(Posicion posicion)
        {
            var posicionEncontrada = _dataContext.Posiciones.Find(posicion.Id);
            if (posicionEncontrada != null)
            {
                posicionEncontrada.Nombre = posicion.Nombre;
                _dataContext.SaveChanges();
            }
            return posicionEncontrada;
        }

        public Posicion DeletePosicion(int idPosicion)
        {
            var posicionEncontrada = _dataContext.Posiciones.Find(idPosicion); 
            if (posicionEncontrada != null)
            {
                _dataContext.Posiciones.Remove(posicionEncontrada);
                _dataContext.SaveChanges();
            }
            return posicionEncontrada;
        }
    }
}