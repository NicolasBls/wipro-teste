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
        public Clientes()
        {
            Locacoes = new HashSet<Locacoes>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public ClientesStatus Status { get; set; }

        public virtual ICollection<Locacoes> Locacoes { get; set; }

    }
}
