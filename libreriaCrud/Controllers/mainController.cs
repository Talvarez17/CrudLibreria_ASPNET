using libreriaCrud.App.Autor;
using libreriaCrud.App.Libro;
using libreriaCrud.App.Usuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace libreriaCrud.Controllers
{
    [Route("api")]
    [ApiController]
    public class mainController : Controller
    {
        private readonly IMediator _mediator;

        public mainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ------------------------------- Controlador de libros --------------------------------------
        [HttpPost("libro/agregar")]
        public async Task<ActionResult<Unit>> CrearLibro(libroAgregar.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("libro/editar")]
        public async Task<ActionResult<Unit>> ActualizarLibro(libroActualizar.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet("libro/obtener/todo")]
        public async Task<ActionResult<List<libroDto>>> ObtenerLibro()
        {
            return await _mediator.Send(new libroConsulta.Ejecuta());
        }

        [HttpGet("libro/idUsuario/{id}")]
        public async Task<ActionResult<List<libroDto>>> ObtenerPorIdUsuarioLibro(Guid id)
        {
            return await _mediator.Send(new libroConsultaId.Ejecuta { Idusuario = id });
        }

        [HttpGet("libro/id/{id}")]
        public async Task<ActionResult<List<libroDto>>> ObtenerPorIdLibro(Guid id)
        {
            return await _mediator.Send(new libroConsultaPorId.Ejecuta { Id = id });
        }

        [HttpDelete("libro/borrar/{id}")]
        public async Task<ActionResult<Unit>> BorrarLibro(Guid id)
        {
            return await _mediator.Send(new libroBorrar.Ejecuta { Id = id });
        }

        // ------------------------------- Controlador de autores --------------------------------------

        [HttpPost("autor/agregar")]
        public async Task<ActionResult<Unit>> CrearAutor(autorAgregar.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("autor/editar")]
        public async Task<ActionResult<Unit>> ActualizarAutor(autorActualizar.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet("autor/obtener/todo")]
        public async Task<ActionResult<List<autorDto>>> ObtenerAutor()
        {
            return await _mediator.Send(new autorConsulta.Ejecuta());
        }

        [HttpGet("autor/id/{id}")]
        public async Task<ActionResult<List<autorDto>>> ObtenerPorIdAutor(Guid id)
        {
            return await _mediator.Send(new autorConsultaId.Ejecuta { Id = id });
        }

        [HttpDelete("autor/borrar/{id}")]
        public async Task<ActionResult<Unit>> BorrarAutor(Guid id)
        {
            return await _mediator.Send(new autorBorrar.Ejecuta { Id = id });
        }
        // ------------------------------- Controlador de usuarios --------------------------------------

        [HttpPost("usuario/agregar")]
        public async Task<ActionResult<Unit>> CrearUsuario(usuarioAgregar.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPost("usuario/login")]
        public async Task<ActionResult<usuarioDto>> Login(usuarioLogin.Ejecuta data)       {
            return await _mediator.Send(data);
        }
    }
}
