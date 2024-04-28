using libreriaCrud.Persistence.Libro;
using MediatR;

namespace libreriaCrud.App.Libro
{
    public class libroBorrar
    {
        public class Ejecuta : IRequest<Unit>
        {
            public Guid? Id { get; set; }
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

                _contexto.libro.Remove(lbr);
                await _contexto.SaveChangesAsync(cancellationToken);

                return Unit.Value;

            }
        }
    }
}
