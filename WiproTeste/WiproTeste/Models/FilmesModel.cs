using WiproTeste.Data.Entities.Enuns;

namespace WiproTeste.Models
{
    public class FilmesModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public FilmesStatus Status { get; set; }
    }
}
