using FluentValidation;
using libreriaCrud.Models.Usuario;
using libreriaCrud.Persistence.Usuario;
using MediatR;

namespace libreriaCrud.App.Usuario
{
    public class usuarioAgregar
    {
        public class Ejecuta : IRequest
        {
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Correo { get; set; }
            public string? Contraseña { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
                RuleFor(x => x.Correo).NotEmpty();
                RuleFor(x => x.Contraseña).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly usuarioPersistence _contexto;

            public Manejador(usuarioPersistence contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var user = new usuarioModel
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Correo = request.Correo,
                    Contraseña = request.Contraseña
                };

                _contexto.usuario.Add(user);

                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puede guardar el usuario");

            }

        }
    }
}
