using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioArbitro
    {
        public Arbitro AddArbitro(Arbitro arbitro);
        public IEnumerable<Arbitro> GetAllArbitros();
        public Arbitro GetArbitro(int idArbitro);
        public Arbitro UpdateArbitro(Arbitro arbitro);

    }
}