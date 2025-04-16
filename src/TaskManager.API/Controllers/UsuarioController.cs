using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Usuario.Queries;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            try
            {
                var query = new GetAllUsuariosQuery();
                var usuarios = await _mediator.Send(query);
                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{usuarioId}")]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios(int usuarioId)
        {
            try
            {
                var query = new GetUsuarioByIdQuery(usuarioId);
                var usuario = await _mediator.Send(query);
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
