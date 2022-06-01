using WiproTeste.Data.Entities.Enuns;

namespace WiproTeste.DTOs
{
    public class ClientesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Status { get; set; }
        public List<LocacoesDto> Locacoes { get; set; }

    }
}
