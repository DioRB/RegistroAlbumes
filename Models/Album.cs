using System.Reflection.Metadata.Ecma335;

namespace RegistroAlbumes.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string Nombre{ get; set; }
        public string Autor { get; set; }
        public DateOnly FechaLanzamiento { get; set; }
        public decimal Puntuacion { get; set; }
        public string Enlace { get; set; }
    }
}
