using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WiproTeste.Controllers;
using WiproTeste.Data.Entities;
using WiproTeste.Data.Entities.Enuns;
using WiproTeste.Models;
using WiproTeste.Profiles;
using Xunit;

namespace WiproTeste.Tester.Controllers
{
    //TODO: Deveria fazer mais testes
    //TODO: Testes do repositorio
    //TODO: poderia testar se os valores salvos pelo repositório são os mesmos valores enviados para o controller


    public class ClientesControllerTest
    {
        private static IMapper _mapper;
        private readonly ClientesRepositoryMock clientesRepository;
        private readonly ClientesController clientesController;


        public ClientesControllerTest()
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
            clientesRepository = new ClientesRepositoryMock();
            clientesController = new ClientesController(clientesRepository, _mapper);
        }

        [Fact]
        public void GetById_DeveRetornarCliente_QuandoIdForValido()
        {
            // Given
            clientesRepository.GetByIdResult = new ClientesModel(id: 1, nome: "Julio", documento: "129083712", status: ClientesStatus.Ativo);            

            // When
            IActionResult result = clientesController.GetById(1);

            // Then
            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void GetById_DeveRetornarNotFound_QuandoIdNaoForEncontrado()
        {
            // Given
            clientesRepository.GetByIdResult = null;

            // When
            IActionResult result = clientesController.GetById(1);

            // Then
            Assert.True(result is NotFoundObjectResult);
        }

        [Fact]
        public void Post_DeveSalvarCliente_QuandoModelForValida()
        {
            // Given
            var cliente = new ClientesModel(id: 1, nome: "Julio", documento: "129083712", status: ClientesStatus.Ativo);
            clientesRepository.CreateResult = cliente;

            // When
            IActionResult result = clientesController.Post(new ClienteRequestDto(nome:"Julio", documento: "129083712"));

            // Then
            Assert.True(result is CreatedResult);
        }

        [Fact]
        public void Post_DeveRetornarBadRequest_QuandoModelNaoForValida()
        {
            // Given
            clientesRepository.CreateResult = null;

            // When
            IActionResult result = clientesController.Post(new ClienteRequestDto(nome: "Julio", documento: "129083712"));

            // Then
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact]
        public void Devolver_DeveRetornarOk_QuandoDevolver()
        {
            // Given
            clientesRepository.DevolverResult = "Devolvido";

            // When
            IActionResult result = clientesController.Devolver(1,1);

            // Then
            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Update_DeveAtualizarCliente_QuandoModelForValida()
        {
            // Given
            var cliente = new ClientesModel(id: 1, nome: "Julio", documento: "129083712", status: ClientesStatus.Ativo);
            clientesRepository.UpdateResult = cliente;

            // When
            IActionResult result = clientesController.Put(new ClienteRequestDto(id: 1, nome: "Julio", documento: "129083712"));

            // Then
            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Update_DeveRetornarNotFound_QuandoNaoEncontrado()
        {
            // Given
            clientesRepository.UpdateResult = null;

            // When
            IActionResult result = clientesController.Put(new ClienteRequestDto(id: 1, nome: "Julio", documento: "129083712"));

            // Then
            Assert.True(result is NotFoundObjectResult);
        }

        [Fact]
        public void Delete_DeveDeletar_QuandoForValida()
        {
            // Given
            clientesRepository.DeleteResult = true;

            // When
            IActionResult result = clientesController.Delete(1);

            // Then
            Assert.True(result is NoContentResult);
        }

        [Fact]
        public void Delete_DeveRetornarNotFound_QuandoNaoEncontrar()
        {
            // Given
            clientesRepository.DeleteResult = false;

            // When
            IActionResult result = clientesController.Delete(1);

            // Then
            Assert.True(result is NotFoundObjectResult);
        }

        [Fact]
        public void Locar_DeveLocar_QuandoForValido()
        {
            // Given
            var cliente = new ClientesModel(id: 1, nome: "Julio", documento: "129083712", status: ClientesStatus.Ativo);
            clientesRepository.LocarResult = cliente;

            // When
            IActionResult result = clientesController.Locar(1,1);

            // Then
            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Locar_DeveRetornarNotFound_QuandoNaoEncontar()
        {
            // Given
            clientesRepository.LocarResult = null;

            // When
            IActionResult result = clientesController.Locar(1, 1);

            // Then
            Assert.True(result is NotFoundObjectResult);
        }
    }
}
