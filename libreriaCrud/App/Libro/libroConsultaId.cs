using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using libreriaCrud.Models.Libro;
using libreriaCrud.Persistence.Libro;

namespace libreriaCrud.App.Libro
{
    public class libroConsultaId
    {
        public class Ejecuta : IRequest<List<libroDto>>
        {
            public Guid? Idusuario { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, List<libroDto>>
        {

            private readonly libroPersistence _contexto;
            private readonly IMapper _mapper;

            public Manejador(libroPersistence contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<libroDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libros = await _contexto.libro
                    .Where(libro => libro.Idusuario == request.Idusuario)
                    .ToListAsync(cancellationToken);

                var librosDto = _mapper.Map<List<libroModel>, List<libroDto>>(libros);
                return librosDto;
            }
        }
    }
}
