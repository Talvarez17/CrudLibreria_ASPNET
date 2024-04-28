using FluentValidation;
using libreriaCrud.Models.Libro;
using libreriaCrud.Persistence.Libro;
using MediatR;

namespace libreriaCrud.App.Libro
{
    public class libroAgregar
    {
        public class Ejecuta : IRequest
        {
            public string? Nombre { get; set; }
            public string? Sinopsis { get; set; }
            public string? Editorial { get; set; }
            public DateTime? Fecha { get; set; }
            public Guid? Autor { get; set; }
            public Guid? Idusuario { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Sinopsis).NotEmpty();
                RuleFor(x => x.Editorial).NotEmpty();
                RuleFor(x => x.Fecha).NotEmpty();
                RuleFor(x => x.Autor).NotEmpty();
                RuleFor(x => x.Idusuario).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly libroPersistence _contexto;

            public Manejador(libroPersistence contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var lbr = new libroModel
                {
                    Nombre = request.Nombre,
                    Sinopsis = request.Sinopsis,
                    Editorial = request.Editorial,
                    Fecha = request.Fecha,
                    Autor = request.Autor,
                    Idusuario = request.Idusuario
                };

                _contexto.libro.Add(lbr);

                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puede guardar el libro");

            }
        }
    }
}
