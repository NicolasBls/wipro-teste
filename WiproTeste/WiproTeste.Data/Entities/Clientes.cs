using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiproTeste.Data.Entities.Enuns;

namespace WiproTeste.Data.Entities
{
    public class Clientes
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Documento { get; set; }

        [Required]
        public ClientesStatus Status { get; set; }

        public Clientes (string nome, string documento)
        {
            Nome = nome;
            Documento = documento;
            Status = ClientesStatus.Ativo;
        }
    }
}
