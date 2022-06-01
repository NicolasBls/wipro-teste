using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WiproTeste.Controllers;
using WiproTeste.Data.Entities;
using WiproTeste.Data.Entities.Enuns;
using WiproTeste.DTOs;
using WiproTeste.Profiles;
using WiproTeste.Tester.Mocks;
using Xunit;

namespace WiproTeste.Tester.Controllers
{
    public class FilmesControllerTest
    {
        private static IMapper _mapper;
        private readonly FilmesRepositoryMock filmesRepository;
        private readonly FilmesController filmesController;


        public FilmesControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            filmesRepository = new FilmesRepositoryMock();
            filmesController = new FilmesController(filmesRepository, _mapper);
        }

        [Fact]
        public void Disponiveis_DeveRetornarListadeFilmesDisponiveis_Sempre()
        {
            // Given
            filmesRepository.DisponiveisResult = new List<FilmesModel>();

            // When
            IActionResult result = filmesController.Disponiveis();

            // Then
            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Locados_DeveRetornarListadeFilmesLocados_Sempre()
        {
            // Given
            filmesRepository.LocadosResult = new List<FilmesModel>();

            // When
            IActionResult result = filmesController.Locados();

            // Then
            Assert.True(result is OkObjectResult);
        }
    }
}
