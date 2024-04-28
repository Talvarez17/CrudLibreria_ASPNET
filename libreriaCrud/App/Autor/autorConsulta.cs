using Microsoft.EntityFrameworkCore;
using AutoMapper;
using libreriaCrud.Models.Autor;
using libreriaCrud.Persistence.Autor;
using MediatR;

namespace libreriaCrud.App.Autor
{
    public class autorConsulta
    {
        public class Ejecuta : IRequest<List<autorDto>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<autorDto>>
        {

            private readonly autorPersistence _contexto;
            private readonly IMapper _mapper;

            public Manejador(autorPersistence contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<autorDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.autor.ToListAsync(cancellationToken);
                var autoresDto = _mapper.Map<List<autorModel>, List<autorDto>>(autores);
                return autoresDto;
            }
        }
    }
}
