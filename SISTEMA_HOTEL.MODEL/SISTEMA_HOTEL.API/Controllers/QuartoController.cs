using Microsoft.AspNetCore.Mvc;
using SISTEMA_HOTEL.MODEL.Models;
using SISTEMA_HOTEL.MODEL.Services;
using SISTEMA_HOTEL.MODEL.ViewModel;

namespace SISTEMA_HOTEL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartoController : Controller
    {
        private SISTEMA_HOTELContext _context;
        private ServiceQuarto _service;

        public QuartoController(SISTEMA_HOTELContext context)
        {
            _context = context;
            _service = new ServiceQuarto(_context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.oRepositoryQuarto.SelecionarTodosAsync());
        }

        [HttpGet("GetQuartosById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.oRepositoryQuarto.SelecionarChaveAsync(id));
        }

        [HttpPost("PostQuartos")]
        public async Task<IActionResult> Post(QuartoVM quartovm)
        {
            await _service.IncluirQuartoAsync(quartovm);
            return Ok("Quarto Cadastrado com sucesso");
        }

        [HttpPut("PutQuartos")]
        public async Task<IActionResult> Put(QuartoVM quartoVM)
        {
            await _service.AlterarQuartoAsync(quartoVM);
            return Ok("Quarto Cadastrado com sucesso");
        }

        [HttpDelete("DeleteQuarto/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.oRepositoryQuarto.ExcluirAsync(id);

                return Ok("Quarto Excluido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
