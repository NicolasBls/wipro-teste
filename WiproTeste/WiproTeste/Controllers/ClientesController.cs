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
                return NotFound("Cliente não localizado.");

            var resultMapped = mapper.Map<ClientesModel>(result);

            return Ok(resultMapped);
        }

        [HttpGet("List")]
        public IActionResult GetAll()
        {
            var result = clientesRepository.GetAll();
            var resultMapped = mapper.Map<List<ClientesModel>>(result);

            return Ok(resultMapped);
        }

        [HttpPost]
        public IActionResult Post(ClientesModel clientesModel)
        {
            var clientesMapped = mapper.Map<Clientes>(clientesModel);
            var result = clientesRepository.Create(clientesMapped);
            if (result == null)
                return BadRequest("Documento já cadastrado.");

            var resultMapped = mapper.Map<ClientesModel>(result);

            return Created("", resultMapped);
        }

        [HttpPut]
        public IActionResult Put(ClientesModel clientesModel)
        {
            var clientesMapped = mapper.Map<Clientes>(clientesModel);
            var result = clientesRepository.Update(clientesMapped);
            if (result == null)
                return NotFound("Cliente não localizado.");

            var resultMapped = mapper.Map<ClientesModel>(result);

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
        public IActionResult Locar(int id, int[] filmesId)
        {
            var result = clientesRepository.Locar(id, filmesId);
            if (result == null)
                return NotFound("Cliente ou filme não localizado.");

            var resultMapped = mapper.Map<ClientesModel>(result);

            return Ok(resultMapped);

        }

        [HttpPost("{id}/Devolver")]
        public IActionResult Devolver(int id, int[] filmesId)
        {
            var result = clientesRepository.Devolver(id, filmesId);
            if (result == null)
                return NotFound("Cliente não localizado.");

            var resultMapped = mapper.Map<ClientesModel>(result);

            return Ok(resultMapped);

        }
    }
}
