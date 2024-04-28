using FluentValidation;
using libreriaCrud.Persistence.Autor;
using MediatR;

namespace libreriaCrud.App.Autor
{
    public class autorActualizar
    {
        public class Ejecuta : IRequest
        {
            public Guid? Id { get; set; }
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Nacionalidad { get; set; }
            public DateTime? Fecha { get; set; }
        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
                RuleFor(x => x.Nacionalidad).NotEmpty();
                RuleFor(x => x.Fecha).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            private readonly autorPersistence _contexto;

            public Manejador(autorPersistence contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var aut = await _contexto.autor.FindAsync(request.Id);

                if (aut == null)
                {
                    throw new Exception("Autor no encontrado");
                }

                aut.Nombre = request.Nombre;
                aut.Apellido = request.Apellido;
                aut.Nacionalidad = request.Nacionalidad;
                aut.Fecha = request.Fecha;


                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puede actualizar el autor");

            }
        }
    }
}
