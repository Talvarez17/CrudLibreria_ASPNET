using FluentValidation;
using libreriaCrud.Models.Autor;
using libreriaCrud.Persistence.Autor;
using MediatR;

namespace libreriaCrud.App.Autor
{
    public class autorAgregar
    {
        public class Ejecuta : IRequest
        {
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Nacionalidad { get; set; }
            public DateTime? Fecha { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
                RuleFor(x => x.Nacionalidad).NotEmpty();
                RuleFor(x => x.Fecha).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly autorPersistence _contexto;

            public Manejador(autorPersistence contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var aut = new autorModel
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Nacionalidad = request.Nacionalidad,
                    Fecha = request.Fecha
                };

                _contexto.autor.Add(aut);

                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puede guardar el autor");

            }
        }
    }
}
