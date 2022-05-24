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
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public FilmesStatus Status { get; set; }

        public Filmes(string titulo)
        {
            Titulo = titulo;
            Status = FilmesStatus.Disponivel;
        } 
    }
}
