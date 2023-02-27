using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioArbitro : IRepositorioArbitro
    {
        private readonly DataContext _dataContext = new DataContext();

        public Arbitro AddArbitro(Arbitro arbitro)
        {
            var arbitroInsertado = _dataContext.Arbitros.Add(arbitro);
            _dataContext.SaveChanges();
            return arbitroInsertado.Entity;
        }

        public IEnumerable<Arbitro> GetAllArbitros()
        {
            return _dataContext.Arbitros;
        }
        public Arbitro GetArbitro(int idArbitro)
        {
            var arbitroEncontrado = _dataContext.Arbitros.Find(idArbitro);
            return arbitroEncontrado;
        }
        public Arbitro UpdateArbitro(Arbitro arbitro)
        {
            var arbitroEncontrado = _dataContext.Arbitros.Find(arbitro.Id);
            if (arbitroEncontrado != null)
            {
                arbitroEncontrado.Nombre = arbitro.Nombre;
                arbitroEncontrado.Documento = arbitro.Documento;
                arbitroEncontrado.Telefono = arbitro.Telefono;
                arbitroEncontrado.Colegio = arbitro.Colegio;
                _dataContext.SaveChanges();
            }
            return arbitroEncontrado;
        }
    }
}