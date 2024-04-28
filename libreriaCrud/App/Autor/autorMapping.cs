using libreriaCrud.Models.Autor;
using AutoMapper;

namespace libreriaCrud.App.Autor
{
    public class autorMapping: Profile
    {
        public autorMapping()
        {
            CreateMap<autorModel, autorDto>();
        }
    }
}
