using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiproTeste.Data.Entities
{
    public class LocacoesModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FilmeId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public virtual ClientesModel Cliente { get; set; } = null!;
        public virtual FilmesModel Filme { get; set; } = null!;

        public LocacoesModel()
        {
        }
        public LocacoesModel(int clienteId, int filmeId)
        {
            ClienteId = clienteId;
            FilmeId = filmeId;
            DataLocacao = DateTime.Now;
            DataVencimento = DateTime.Now.AddDays(2).Date;
        }
    }
}
