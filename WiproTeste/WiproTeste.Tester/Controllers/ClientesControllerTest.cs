using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiproTeste.Controllers;
using WiproTeste.Data.Entities;
using WiproTeste.Data.Entities.Enuns;
using WiproTeste.Data.Repositories;
using WiproTeste.Models;
using WiproTeste.Profiles;
using Xunit;

namespace WiproTeste.Tester.Controllers
{

    public class ClientesControllerTest
    {
        private static IMapper _mapper;
 
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
        }

        [Fact]
        public void GetById_DeveRetornarCliente_QuandoIdForValido()
        {
            // TODO: mover para o inicializador
            ClientesRepositoryMock clientesRepository = new ClientesRepositoryMock();

            // Given
            clientesRepository.GetByIdResult = new Clientes(id: 1, nome: "Julio", documento: "129083712", status: ClientesStatus.Ativo);            
            var clientsController = new ClientesController(clientesRepository, _mapper);

            // When
            IActionResult result = clientsController.GetById(1);

            // Then
            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void GetById_DeveRetornarNotFound_QuandoIdNaoForEncontrado()
        {
            // TODO: mover para o inicializador
            ClientesRepositoryMock clientesRepository = new ClientesRepositoryMock();

            // Given
            clientesRepository.GetByIdResult = null;
            var clientsController = new ClientesController(clientesRepository, _mapper);

            // When
            IActionResult result = clientsController.GetById(1);

            // Then
            Assert.True(result is NotFoundObjectResult);
        }

        [Fact]
        public void PostCliente_DeveSalvarCliente_QuandoModelForValida(){
            // TODO: mover para o inicializador
            ClientesRepositoryMock clientesRepository = new ClientesRepositoryMock();

            // Given
            var myClient = new Clientes(id: 1, nome: "Julio", documento: "129083712", status: ClientesStatus.Ativo);
            clientesRepository.createResult = myClient;
            var clientsController = new ClientesController(clientesRepository, _mapper);

            // When
            IActionResult result = clientsController.Post(new ClienteRequestModel(nome:"Julio", documento: "129083712"));

            // Then
            Assert.True(result is CreatedResult);

            // TODO: poderia testar se os valores salvos pelo repositório são os mesmos valores enviados para o controller
            //Assert.IsType<Clientes>(result.Value);

        }
    }
}
