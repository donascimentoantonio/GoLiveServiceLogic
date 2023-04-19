using GoLiveServiceLogic_v2.Application.AppServices.Interfaces;
using GoLiveServiceLogic_v2.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GoLiveServiceLogic_v2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDto usuarioDto)
        {
            var result = await _usuarioService.CreateAsync(usuarioDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _usuarioService.GetAllAsync();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] int id)
        {
            var result = await _usuarioService.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
