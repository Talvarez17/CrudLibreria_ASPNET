using FluentValidation;
using libreriaCrud.Persistence.Libro;
using MediatR;

namespace libreriaCrud.App.Libro
{
    public class libroActualizar
    {
        public class Ejecuta : IRequest
        {
            public Guid? Id { get; set; }
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
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Sinopsis).NotEmpty();
                RuleFor(x => x.Editorial).NotEmpty();
                RuleFor(x => x.Fecha).NotEmpty();
                RuleFor(x => x.Autor).NotEmpty();
                RuleFor(x => x.Idusuario).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            private readonly libroPersistence _contexto;

            public Manejador(libroPersistence contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var lbr = await _contexto.libro.FindAsync(request.Id);

                if (lbr == null)
                {
                    throw new Exception("Libro no encontrado");
                }

                lbr.Nombre = request.Nombre;
                lbr.Sinopsis = request.Sinopsis;
                lbr.Editorial = request.Editorial;
                lbr.Fecha = request.Fecha;
                lbr.Autor = request.Autor;
                lbr.Idusuario = request.Idusuario;


                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puede actualizar el libro");

            }
        }
    }
}
