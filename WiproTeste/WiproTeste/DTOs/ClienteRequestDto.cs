namespace WiproTeste.DTOs
{
    public class ClienteRequestDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Documento { get; set; }


        public ClienteRequestDto(string nome, string documento, int? id = 1)
        {
            Nome = nome;
            Documento = documento;
            Id = Id;
        }
        public ClienteRequestDto()
        {

        }
    }
}
