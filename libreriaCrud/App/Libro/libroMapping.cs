using libreriaCrud.Models.Libro;
using AutoMapper;

namespace libreriaCrud.App.Libro
{
    public class libroMapping: Profile
    {
        public libroMapping()
        {
            CreateMap<libroModel, libroDto>();
        }
    }
}
