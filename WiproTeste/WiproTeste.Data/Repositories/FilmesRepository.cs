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
        public FilmesModel GetById(int id);
        public List<FilmesModel> GetAll();
        public FilmesModel Create(FilmesModel cliente);
        public FilmesModel Update(FilmesModel cliente);
        public bool Delete(int id);
        public List<FilmesModel> Disponiveis();
        public List<FilmesModel> Locados();
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

        public FilmesModel Create(FilmesModel filme)
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

        public List<FilmesModel> GetAll()
        {
            var result = dataContext.Filmes.ToList();
            return result;
        }

        public FilmesModel GetById(int id)
        {
            var result = dataContext.Filmes.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<FilmesModel> Disponiveis()
        {
            var result = dataContext.Filmes.Where(x => x.Status == FilmesStatus.Disponivel).ToList();
            return result;
        }

        public List<FilmesModel> Locados()
        {
            var result = dataContext.Filmes.Where(x => x.Status == FilmesStatus.Locado).ToList();
            return result;
        }

        public FilmesModel Update(FilmesModel filme)
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
