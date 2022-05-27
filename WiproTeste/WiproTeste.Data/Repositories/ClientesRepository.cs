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
        public Clientes GetById(int id);
        public List<Clientes> GetAll();
        public Clientes Create(Clientes cliente);
        public Clientes Update(Clientes cliente);
        public bool Delete(int id);
        public Clientes Locar(int id, int[] filmesId);
        public Clientes Devolver(int id, int[]? filmesId);

    }
    public class ClientesRepository : IClientesRepository
    {
        private readonly DataContext dataContext;
        public ClientesRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }


        public Clientes GetById(int id)
        {
            var result = dataContext.Clientes.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<Clientes> GetAll()
        {
            var result = dataContext.Clientes.ToList();
            return result;
        }

        public Clientes Create(Clientes cliente)
        {
            var clienteDB = dataContext.Clientes.FirstOrDefault(x => x.Documento.Equals(cliente.Documento));
            if (clienteDB != null)
                return null;

            cliente.Status = ClientesStatus.Ativo;
            dataContext.Clientes.Add(cliente);
            dataContext.SaveChanges();
            var result = dataContext.Clientes.FirstOrDefault(x => x.Documento.Equals(cliente.Documento));
            return result;
        }

        public Clientes Update(Clientes cliente)
        {
            var clienteDB = dataContext.Clientes.FirstOrDefault(x => x.Id == cliente.Id);
            if (clienteDB != null)
                return null;
            clienteDB.Nome = cliente.Nome;
            clienteDB.Documento = cliente.Documento;

            dataContext.Clientes.Update(clienteDB);
            dataContext.SaveChanges();
            var result = clienteDB;
            return result;
        }

        public bool Delete(int id)
        {
            var clienteDB = dataContext.Clientes.FirstOrDefault(x => x.Id == id);
            if (clienteDB != null)
                return false;

            clienteDB.Status = ClientesStatus.Inativo;
            dataContext.Clientes.Update(clienteDB);
            return true;
        }

        public Clientes Locar(int id, int[] filmesId)
        {
            var clienteDB = dataContext.Clientes.FirstOrDefault(x => x.Id == id);
            var existeFilmesDB = dataContext.Filmes.Any(x => !filmesId.Contains(x.Id));
            if (clienteDB == null || existeFilmesDB)
                return null;

            var locacoes = new List<Locacoes>();

            foreach (var filmeId in filmesId)
                locacoes.Add(new Locacoes(id, filmeId, DateTime.Now));

            clienteDB.Locacoes = locacoes;
            dataContext.Clientes.Update(clienteDB);
            dataContext.SaveChanges();
            var result = dataContext.Clientes.FirstOrDefault(x => x.Id == id);

            return result;
        }

        public Clientes Devolver(int id, int[]? filmesId)
        {
            var clienteDB = dataContext.Clientes.FirstOrDefault(x => x.Id == id);
            if (clienteDB == null)
                return null;

            var locacoes = dataContext.Locacoes.Where(x => x.ClienteId == id && (filmesId == null || filmesId.Contains(x.FilmeId)));

            foreach (var locacao in locacoes)
                locacao.DataDevolucao = DateTime.Now;

            dataContext.Locacoes.UpdateRange(locacoes);
            dataContext.SaveChanges();
            var result = dataContext.Clientes.FirstOrDefault(x => x.Id == id);

            return result;
        }
    }
}
