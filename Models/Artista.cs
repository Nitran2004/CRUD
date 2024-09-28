using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Artista
    {
        [Key]
        public int ArtistasId { get; set; } // Cambiado a 'public'

        public string Nombre { get; set; }

        public string Genero { get; set; }

        public string Edad { get; set; }
    }
}
