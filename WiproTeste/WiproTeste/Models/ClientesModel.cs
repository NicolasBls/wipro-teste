using WiproTeste.Data.Entities.Enuns;

namespace WiproTeste.Models
{
    public class ClientesModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public ClientesStatus Status { get; set; }
    }
}
