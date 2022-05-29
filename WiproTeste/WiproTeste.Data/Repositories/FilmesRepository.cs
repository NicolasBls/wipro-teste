using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiproTeste.Data.Entities;
using WiproTeste.Data.Entities.Enuns;

namespace WiproTeste.Data.Repositories
{
    public interface IFilmesRepository
    {
        public Filmes GetById(int id);
        public List<Filmes> GetAll();
        public Filmes Create(Filmes cliente);
        public Filmes Update(Filmes cliente);
        public bool Delete(int id);
        public List<Filmes> Disponiveis();
        public List<Filmes> Locados();
        public bool Locar(int id);
        public string Devolver(int id);

    }
    public class FilmesRepository : IFilmesRepository
    {
        private readonly DataContext dataContext;
        public FilmesRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Filmes Create(Filmes filme)
        {
            var filmeDB = dataContext.Filmes.FirstOrDefault(x => x.Titulo.Equals(filme.Titulo));
            if (filmeDB != null)
                return null;

            filme.Status = FilmesStatus.Disponivel;
            dataContext.Filmes.Add(filme);
            dataContext.SaveChanges();
            var result = dataContext.Filmes.FirstOrDefault(x => x.Titulo.Equals(filme.Titulo));
            return result;  
        }

        public bool Delete(int id)
        {
            var filmesDB = dataContext.Filmes.FirstOrDefault(x => x.Id == id);
            if (filmesDB != null)
                return false;

            filmesDB.Status = FilmesStatus.Deletado;
            dataContext.Filmes.Update(filmesDB);
            return true;
        }

        public List<Filmes> GetAll()
        {
            var result = dataContext.Filmes.ToList();
            return result;
        }

        public Filmes GetById(int id)
        {
            var result = dataContext.Filmes.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<Filmes> Disponiveis()
        {
            var result = dataContext.Filmes.Where(x=>x.Status == FilmesStatus.Disponivel).ToList();
            return result;
        }

        public List<Filmes> Locados()
        {
            var result = dataContext.Filmes.Where(x => x.Status == FilmesStatus.Locado).ToList();
            return result;
        }

        public Filmes Update(Filmes filme)
        {
            var filmesDB = dataContext.Filmes.FirstOrDefault(x => x.Id == filme.Id);
            if (filmesDB != null)
                return null;
            filmesDB.Titulo = filme.Titulo;
            
            dataContext.Filmes.Update(filmesDB);
            dataContext.SaveChanges();
            var result = filmesDB;
            return result;
        }

        public bool Locar(int id)
        {
            var filmesDB = dataContext.Filmes.FirstOrDefault(x => x.Id == id && x.Status == FilmesStatus.Disponivel);
            if (filmesDB == null)
                return false;

            filmesDB.Status = FilmesStatus.Locado;
            dataContext.Update(filmesDB);
            return true;
        }

        public string Devolver(int id)
        {
            var filmesDB = dataContext.Filmes.FirstOrDefault(x => x.Id == id && x.Status == FilmesStatus.Locado);
            if (filmesDB == null)
                return "Filme não localizado.";

            filmesDB.Status = FilmesStatus.Disponivel;
            dataContext.Update(filmesDB);
            dataContext.SaveChanges();
            return null;
        }
    }
}
