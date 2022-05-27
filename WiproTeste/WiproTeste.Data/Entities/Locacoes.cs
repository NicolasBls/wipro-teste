using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiproTeste.Data.Entities
{
    public class Locacoes
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FilmeId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public virtual Clientes Cliente { get; set; } = null!;
        public virtual Filmes Filme { get; set; } = null!;

        public Locacoes()
        {
        }
        public Locacoes(int clienteId, int filmeId, DateTime dataLocacao)
        {
            ClienteId = clienteId;
            FilmeId = filmeId;
            DataLocacao = dataLocacao;
        }
    }
}
