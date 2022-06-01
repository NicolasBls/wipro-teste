using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiproTeste.Data.Entities.Enuns;

namespace WiproTeste.Data.Entities
{
    public class ClientesModel
    {
        public ClientesModel()
        {
            Locacoes = new HashSet<LocacoesModel>();
        }

        public ClientesModel(int id, string nome, string documento, ClientesStatus status, ICollection<LocacoesModel>? locacoes = null) {
            this.Id = id;
            this.Nome = nome;
            this.Documento = documento;
            this.Status = status;
            this.Locacoes = locacoes ?? new HashSet<LocacoesModel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public ClientesStatus Status { get; set; }

        public virtual ICollection<LocacoesModel> Locacoes { get; set; }

    }
}
