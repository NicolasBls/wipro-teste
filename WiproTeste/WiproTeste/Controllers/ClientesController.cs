using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WiproTeste.Data.Entities;
using WiproTeste.Data.Repositories;
using WiproTeste.Models;

namespace WiproTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        public readonly IClientesRepository clientesRepository;
        public readonly IMapper mapper;

        public ClientesController(IClientesRepository clientesRepository, IMapper mapper)
        {
            this.clientesRepository = clientesRepository;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = clientesRepository.GetById(id);

            if (result == null)
                // TODO: pode ser melhorado aqui eu poderia criuart erros customizados
                return NotFound("Cliente não localizado.");

            var resultMapped = mapper.Map<ClientesDto>(result);

            return Ok(resultMapped);
        }

        [HttpGet("List")]
        public IActionResult GetAll()
        {
            var result = clientesRepository.GetAll();
            if (result == null)
                return NotFound("Cliente não localizado.");

            var resultMapped = mapper.Map<List<ClientesDto>>(result);

            return Ok(resultMapped);
        }

        [HttpPost]
        public IActionResult Post(ClienteRequestDto clientesModel)
        {
            var clientesMapped = mapper.Map<ClientesModel>(clientesModel);
            var result = clientesRepository.Create(clientesMapped);
            if (result == null)
                return BadRequest("Documento já cadastrado.");

            var resultMapped = mapper.Map<ClientesDto>(result);

            return Created("", resultMapped);
        }

        [HttpPut]
        public IActionResult Put(ClienteRequestDto clientesModel)
        {
            var clientesMapped = mapper.Map<ClientesModel>(clientesModel);
            var result = clientesRepository.Update(clientesMapped);
            if (result == null)
                return NotFound("Cliente não localizado.");

            var resultMapped = mapper.Map<ClientesDto>(result);

            return Ok(resultMapped);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = clientesRepository.Delete(id);
            if (!result)
                return NotFound("Cliente não localizado.");

            return NoContent();
        }

        [HttpPost("{id}/Locar")]
        public IActionResult Locar(int id, int filmeId)
        {
            var result = clientesRepository.Locar(id, filmeId);
            if (result == null)
                return NotFound("Cliente ou filme não localizado ou não disponível para locação.");

            var resultMapped = mapper.Map<ClientesDto>(result);

            return Ok(resultMapped);
        }

        [HttpPost("{id}/Devolver")]
        public IActionResult Devolver(int id, int filmeId)
        {
            var result = clientesRepository.Devolver(id, filmeId);

            return Ok(result);

        }
    }
}
