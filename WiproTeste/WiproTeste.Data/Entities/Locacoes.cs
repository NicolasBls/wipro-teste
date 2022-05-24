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
        [Key]
        public int Id { get; set; }

        [Required]
        public Clientes Cliente { get; set; }

        [Required]
        public Filmes Filme { get; set; }

        [Required]
        public DateTime DataLocacao { get; set; }
        
        public DateTime DataDevolucao { get; set; }

        public Locacoes(Clientes cliente, Filmes filme, DateTime dataLocacao)
        {
            Cliente = cliente;
            Filme = filme;
            DataLocacao = dataLocacao;
        }
    }
}
