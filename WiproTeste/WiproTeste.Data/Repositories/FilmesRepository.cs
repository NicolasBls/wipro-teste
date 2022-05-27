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

            filmesDB.Status = FilmesStatus.Indisponivel;
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
    }
}
