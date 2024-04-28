using libreriaCrud.Persistence.Autor;
using MediatR;

namespace libreriaCrud.App.Autor
{
    public class autorBorrar
    {
        public class Ejecuta : IRequest<Unit>
        {
            public Guid? Id { get; set; }
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

                _contexto.autor.Remove(aut);
                await _contexto.SaveChangesAsync(cancellationToken);

                return Unit.Value;

            }
        }
    }
}
