using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiproTeste.Data.Entities.Enuns;

namespace WiproTeste.Data.Entities
{
    public class Filmes
    {
        public Filmes()
        {
            Locacoes = new HashSet<Locacoes>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public FilmesStatus Status { get; set; }

        public virtual ICollection<Locacoes> Locacoes { get; set; }
    }
}
