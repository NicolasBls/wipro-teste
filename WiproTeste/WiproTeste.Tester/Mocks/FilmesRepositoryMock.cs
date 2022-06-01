using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiproTeste.Data.Entities;
using WiproTeste.Data.Repositories;

namespace WiproTeste.Tester.Mocks
{
    internal class FilmesRepositoryMock : IFilmesRepository
    {
        public List<FilmesModel>? LocadosResult;
        public List<FilmesModel>? DisponiveisResult;
        public List<FilmesModel> Locados()
        {
            return LocadosResult;
        }

        public List<FilmesModel> Disponiveis()
        {
            return DisponiveisResult;
        }

        public bool Locar(int id)
        {
            throw new NotImplementedException();
        }
        public string Devolver(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmesModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public FilmesModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public FilmesModel Update(FilmesModel cliente)
        {
            throw new NotImplementedException();
        }

        public FilmesModel Create(FilmesModel cliente)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
