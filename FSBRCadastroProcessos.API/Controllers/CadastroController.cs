using FSBRCadastroProcessos.API.Application.Interfaces;
using FSBRCadastroProcessos.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FSBRCadastroProcessos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroService _cadastroService;

        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadastro>>> GetAll()
        {
            var cadastros = await _cadastroService.GetAll();
            return Ok(cadastros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cadastro>> GetById(int id)
        {
            var cadastro = await _cadastroService.GetById(id);
            if (cadastro == null)
                return NotFound();

            return Ok(cadastro);
        }

        [HttpPost]
        public async Task<ActionResult<Cadastro>> Create([FromBody] Cadastro cadastro)
        {
            if (cadastro == null)
                return BadRequest("Cadastro não pode ser nulo.");

            var createdCadastro = await _cadastroService.Create(cadastro);
            if (createdCadastro == null)
                return StatusCode(500, "Erro ao criar o cadastro.");

            return CreatedAtAction(nameof(GetById), new { id = createdCadastro.Id }, createdCadastro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cadastro>> Update(int id, [FromBody] Cadastro cadastro)
        {
            if (cadastro == null || cadastro.Id != id)
                return BadRequest("Dados de cadastro inválidos.");

            var updatedCadastro = await _cadastroService.Update(cadastro);
            if (updatedCadastro == null)
                return NotFound("Cadastro não encontrado.");

            return Ok(updatedCadastro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _cadastroService.Delete(id);
            if (!isDeleted)
                return NotFound("Cadastro não encontrado ou erro ao deletar.");

            return NoContent();
        }

    }
}