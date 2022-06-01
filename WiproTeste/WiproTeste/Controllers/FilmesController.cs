using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WiproTeste.Data.Entities;
using WiproTeste.Data.Repositories;
using WiproTeste.DTOs;

namespace WiproTeste.Controllers
{
    // TODO: pode ser melhorado, criar erros customizados

    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        public readonly IFilmesRepository filmesRepository;
        public readonly IMapper mapper;

        public FilmesController(IFilmesRepository filmesRepository, IMapper mapper)
        {
            this.filmesRepository = filmesRepository;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = filmesRepository.GetById(id);

            if (result == null)
                return NotFound();

            var resultMapped = mapper.Map<FilmesDto>(result);

            return Ok(resultMapped);
        }

        [HttpGet("Catalogo")]
        public IActionResult Catalogo()
        {
            var result = filmesRepository.GetAll();
            var resultMapped = mapper.Map<List<FilmesDto>>(result);

            return Ok(resultMapped);
        }

        [HttpGet("Disponiveis")]
        public IActionResult Disponiveis()
        {
            var result = filmesRepository.Disponiveis();
            var resultMapped = mapper.Map<List<FilmesDto>>(result);

            return Ok(resultMapped);
        }

        [HttpGet("Locados")]
        public IActionResult Locados()
        {
            var result = filmesRepository.Locados();
            var resultMapped = mapper.Map<List<FilmesDto>>(result);

            return Ok(resultMapped);
        }

        [HttpPost]
        public IActionResult Post(FilmesDto filmesModel)
        {
            var filmesMapped = mapper.Map<FilmesModel>(filmesModel);
            var result = filmesRepository.Create(filmesMapped);
            if (result == null)
                return BadRequest();

            var resultMapped = mapper.Map<FilmesDto>(result);

            return Created("", resultMapped);
        }

        [HttpPut]
        public IActionResult Put(FilmesDto filmesModel)
        {
            var filmesMapped = mapper.Map<FilmesModel>(filmesModel);
            var result = filmesRepository.Update(filmesMapped);
            if (result == null)
                return NotFound();

            var resultMapped = mapper.Map<FilmesDto>(result);

            return Ok(resultMapped);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = filmesRepository.Delete(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
