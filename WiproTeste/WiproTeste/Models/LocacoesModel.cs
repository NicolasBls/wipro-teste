namespace WiproTeste.Models
{
    public class LocacoesModel
    {
        public int Id { get; set; }
        public ClientesModel Cliente { get; set; }
        public FilmesModel Filme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
