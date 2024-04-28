using Microsoft.EntityFrameworkCore;
using AutoMapper;
using libreriaCrud.Models.Usuario;
using libreriaCrud.Persistence.Usuario;
using MediatR;
using FluentValidation;

namespace libreriaCrud.App.Usuario
{
    public class usuarioLogin
    {
        public class Ejecuta : IRequest<usuarioDto> 
        {
            public string Correo { get; set; } // Quitado el nullable de string para no permitir valores nulos
            public string Contraseña { get; set; } // Quitado el nullable de string para no permitir valores nulos
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Correo).NotEmpty();
                RuleFor(x => x.Contraseña).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, usuarioDto> 
        {
            private readonly usuarioPersistence _contexto;
            private readonly IMapper _mapper;

            public Manejador(usuarioPersistence contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<usuarioDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _contexto.usuario
                    .FirstOrDefaultAsync(user => user.Correo == request.Correo && user.Contraseña == request.Contraseña, cancellationToken);

                if (usuario == null)
                {
                   
                    throw new Exception("Usuario no encontrado");
                }


                var usuarioDto = _mapper.Map<usuarioDto>(usuario);

                return usuarioDto;
            }
        }
    }
}