using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiproTeste.Data.Entities;
using WiproTeste.Data.Entities.Enuns;

namespace WiproTeste.Data.Repositories
{
    public interface IClientesRepository
    {
        public Clientes? GetById(int id);
        public List<Clientes> GetAll();
        public Clientes? Create(Clientes cliente);
        public Clientes Update(Clientes cliente);
        public bool Delete(int id);
        public Clientes Locar(int id, int filmeId);
        public string Devolver(int id, int filmeId);

    }
    public class ClientesRepository : IClientesRepository
    {
        private readonly DataContext dataContext;
        private readonly IFilmesRepository filmesRepository;
        public ClientesRepository(DataContext dataContext, IFilmesRepository filmesRepository)
        {
            this.dataContext = dataContext;
            this.filmesRepository = filmesRepository;
        }


        public Clientes? GetById(int id)
        {
            var result = dataContext.Clientes.FirstOrDefault(x => x.Id == id);
            if (result != null)
                result.Locacoes = result.Locacoes.OrderBy(x=>x.DataDevolucao).ToList();

            return result;
        }

        public List<Clientes> GetAll()
        {
            var result = dataContext.Clientes.ToList();
            if (result == null)
                return null;
            foreach(var item in result)
                item.Locacoes = item.Locacoes.OrderBy(x => x.DataDevolucao).ToList();

            return result;
        }

        public Clientes? Create(Clientes cliente)
        {
            var clienteDB = dataContext.Clientes.FirstOrDefault(x => x.Documento.Equals(cliente.Documento));
            if (clienteDB != null)
                return null;

            cliente.Id = 0;
            cliente.Status = ClientesStatus.Ativo;
            dataContext.Clientes.Add(cliente);
            dataContext.SaveChanges();
            var result = dataContext.Clientes.FirstOrDefault(x => x.Documento.Equals(cliente.Documento));
            return result;
        }

        public Clientes Update(Clientes cliente)
        {
            var clienteDB = dataContext.Clientes.FirstOrDefault(x => x.Id == cliente.Id && x.Status == ClientesStatus.Ativo);
            if (clienteDB == null)
                return null;
                
            clienteDB.Nome = cliente.Nome;
            clienteDB.Documento = cliente.Documento;

            dataContext.Clientes.Update(clienteDB);
            dataContext.SaveChanges();
            var result = dataContext.Clientes.FirstOrDefault(x => x.Id == cliente.Id);
            return result;
        }

        public bool Delete(int id)
        {
            var clienteDB = dataContext.Clientes.FirstOrDefault(x => x.Id == id);
            if (clienteDB == null)
                return false;

            clienteDB.Status = ClientesStatus.Inativo;
            dataContext.Clientes.Update(clienteDB);
            dataContext.SaveChanges();
            return true;
        }

        public Clientes Locar(int id, int filmeId)
        {
            var clienteDB = dataContext.Clientes.FirstOrDefault(x => x.Id == id && x.Status == ClientesStatus.Ativo);
            var existeFilmeDB = dataContext.Filmes.Any(x => filmeId == x.Id && x.Status == FilmesStatus.Disponivel);
            if (clienteDB == null || !existeFilmeDB)
                return null;

            var resultFilme = filmesRepository.Locar(filmeId);
            if (resultFilme == null)
                return null;

            var locacao = new Locacoes(id, filmeId);

            dataContext.Locacoes.Add(locacao);
            dataContext.SaveChanges();
            var result = dataContext.Clientes.FirstOrDefault(x => x.Id == id);

            return result;
        }

        public string Devolver(int id, int filmeId)
        {
            var locacao = dataContext.Locacoes.FirstOrDefault(x => x.ClienteId == id &&  x.FilmeId == filmeId);
            if (locacao == null)
                return "Cliente ou filme não localizado.";


            locacao.DataDevolucao = DateTime.Now;

            var resultFilme = filmesRepository.Devolver(filmeId);
            if (resultFilme != null)
                return resultFilme;

            dataContext.Locacoes.Update(locacao);
            dataContext.SaveChanges();
            if (locacao.DataDevolucao.Value.Date > locacao.DataVencimento.Date)
                return "Devolvido com atrazo.";
            return "Devolvido com sucesso.";
        }
    }
}
