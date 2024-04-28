using libreriaCrud.Models.Usuario;
using AutoMapper;

namespace libreriaCrud.App.Usuario
{
    public class usuarioMapping: Profile
    {
        public usuarioMapping()
        {
            CreateMap<usuarioModel, usuarioDto>();
        }
    }
}
