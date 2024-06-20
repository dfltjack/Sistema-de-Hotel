using Microsoft.AspNetCore.Mvc;
using SISTEMA_HOTEL.MODEL.Models;
using SISTEMA_HOTEL.MODEL.Services;
using SISTEMA_HOTEL.MODEL.ViewModel;

namespace SISTEMA_HOTEL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        private SISTEMA_HOTELContext _context;
        private ServiceReserva _service;

        public ReservaController(SISTEMA_HOTELContext context)
        {
            _context = context;
            _service = new ServiceReserva(_context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.oRepositoryReserva.SelecionarTodosAsync());
        }

        [HttpGet("GetReservasById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.oRepositoryReserva.SelecionarChaveAsync(id));
        }

        [HttpPost("PostReservas")]
        public async Task<IActionResult> Post(ReservaVM reservaVM)
        {
            await _service.IncluirReservaAsync(reservaVM);
            return Ok("Reserva Cadastrada com sucesso");
        }

        [HttpPut("PutReservas")]
        public async Task<IActionResult> Put(ReservaVM reservaVM)
        {
            await _service.AlterarReservaAsync(reservaVM);
            return Ok("Reserva Cadastrada com sucesso");
        }

        [HttpDelete("DeleteReserva/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.oRepositoryReserva.ExcluirAsync(id);

                return Ok("Reserva Excluida com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
