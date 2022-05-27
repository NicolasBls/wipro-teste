﻿namespace WiproTeste.Models
{
    public class LocacoesModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public int FilmeId { get; set; }
        public string FilmeTitulo { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
