using System.ComponentModel.DataAnnotations;

namespace Torneo.App.Dominio
{
    public class Estadio
    {
        public int Id { get; set; }
        [Display(Name = "Nombre del estadio")]
        [Required(ErrorMessage = "El nombre del estadio es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Direccion del estadio")]
        [Required(ErrorMessage = "La direccion es obligatoria")]
        public string Direccion { get; set; }
        [Display(Name = "Ciudad del estadio")]
        [Required(ErrorMessage = "La ciudad es obligatoria")]
        public string Ciudad { get; set; }

        public List<Partido> Partidos { get; set; }
    }
}