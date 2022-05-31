namespace WiproTeste.Models
{
    public class ClienteRequestModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Documento { get; set; }


        public ClienteRequestModel(string nome, string documento)
        {
            Nome = nome;
            Documento = documento;
        }
        public ClienteRequestModel()
        {

        }
    }
}
