using Microsoft.AspNetCore.Mvc;
using SISTEMA_HOTEL.MODEL.Models;
using SISTEMA_HOTEL.MODEL.Services;
using SISTEMA_HOTEL.MODEL.ViewModel;

namespace SISTEMA_HOTEL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospedeController : Controller
    {
        private SISTEMA_HOTELContext _context;
        private ServiceHospede _service;

        public HospedeController(SISTEMA_HOTELContext context)
        {
            _context = context;
            _service = new ServiceHospede(_context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.oRepositoryHospede.SelecionarTodosAsync());
        }

        [HttpGet("GetHospedesById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.oRepositoryHospede.SelecionarChaveAsync(id));
        }

        [HttpPost("PostHospedes")]
        public async Task<IActionResult> Post(HospedeVM hospedeVM)
        {
            await _service.IncluirHospedeAsync(hospedeVM);
            return Ok("Hospede Cadastrado com sucesso");
        }

        [HttpPut("PutHospedes")]
        public async Task<IActionResult> Put(HospedeVM hospedeVM)
        {
            await _service.AlterarHospedeAsync(hospedeVM);
            return Ok("Hospede Cadastrado com sucesso");
        }

        [HttpDelete("DeleteHospede/{id}")]
        public async Task<IActionResult> Delete(int id)
        {   
            try
            {
                await _service.oRepositoryHospede.ExcluirAsync(id);
                
                return Ok("Hospede Excluido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
